using Abp.Domain.Uow;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AspNet = DevExtreme.AspNet.Data;

namespace Tecsmart.Suporte.Devex
{
    public class DataSourceLoader
    {
        public static LoadResult LoadDto<T, TDto>(DbContext context, IMapper _mapper, IQueryable<T> source, DataSourceLoadOptions options)
            where T : class
        {
            var qryResult = AspNet.DataSourceLoader.Load(source, GetModelOptions<T, TDto>(options));
            return GetDtoQueryResult<T, TDto>(context, _mapper, options, qryResult);
        }


        public static LoadResult LoadDto<T, TDto>(DbContext context, IMapper _mapper, Expression<Func<T, bool>> preFilter, DataSourceLoadOptions options) where T : class
        {
            var qryResult = AspNet.DataSourceLoader.Load(context.Set<T>().Where(preFilter), GetModelOptions<T, TDto>(options));
            return GetDtoQueryResult<T, TDto>(context, _mapper, options, qryResult);
        }

        private static LoadResult GetDtoQueryResult<T, TDto>(DbContext context, IMapper _mapper, DataSourceLoadOptions options, LoadResult qryResult) where T : class
        {
            if (options.Select == null || options.Select.Count() == 0)
            {
                options.Filter = null;
                var dtoQryResult = FilterAsDto<T, TDto>(context, _mapper, qryResult, options);
                dtoQryResult.totalCount = qryResult.totalCount;
                return dtoQryResult;
            }
            else return qryResult;
        }

        static DataSourceLoadOptions GetModelOptions<T, TDto>(DataSourceLoadOptions originalOptions)
        {
            var modelOptions = Clone(originalOptions);
            if (modelOptions.Group != null) modelOptions.Sort = modelOptions.Group;
            modelOptions.Group = null;
            return modelOptions;
        }

        static T Clone<T>(T source)
        {
            var serialized = JsonConvert.SerializeObject(source, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            return JsonConvert.DeserializeObject<T>(serialized);
        }

        private static LoadResult FilterAsDto<T, TDto>(DbContext context, IMapper _mapper, LoadResult loadedData, DataSourceLoadOptions loadOptions) where T : class
        {
            Expression<Func<TDto, bool>> lambda = GetDtoByIdPredicate<T, TDto>(context, loadedData);
            var returnData = AspNet.DataSourceLoader.Load(context.Set<T>().ProjectTo<TDto>(_mapper.ConfigurationProvider).Where(lambda), loadOptions);

            return returnData;
        }

        public async static Task<LoadResult> LoadDtoAsync<T, TDto>(DbContext context, IMapper _mapper, IQueryable<T> source, DataSourceLoadOptions options, IActiveUnitOfWork uow)
            where T : class
        {
            var qryResult = await AspNet.DataSourceLoader.LoadAsync(source, GetModelOptions<T, TDto>(options));
            return await GetDtoQueryResultAsync<T, TDto>(context, _mapper, options, qryResult, uow);
        }


        public async static Task<LoadResult> LoadDtoAsync<T, TDto>(IMapper _mapper, IQueryable<T> source, DataSourceLoadOptions options)
        where T : class
        {
            var qryResult = await AspNet.DataSourceLoader.LoadAsync(source.ProjectTo<TDto>(_mapper.ConfigurationProvider), options);
            return qryResult;
        }



        public async static Task<LoadResult> LoadDtoAsync<T, TDto>(DbContext context, IMapper _mapper, Expression<Func<T, bool>> preFilter, DataSourceLoadOptions options, IActiveUnitOfWork uow)
        where T : class
        {
            var qryResult = await AspNet.DataSourceLoader.LoadAsync(context.Set<T>().Where(preFilter), GetModelOptions<T, TDto>(options));
            return await GetDtoQueryResultAsync<T, TDto>(context, _mapper, options, qryResult, uow);
        }

        private static async Task<LoadResult> GetDtoQueryResultAsync<T, TDto>(DbContext context, IMapper _mapper, DataSourceLoadOptions options, LoadResult qryResult, IActiveUnitOfWork uow) where T : class
        {
            if (options.Select == null || options.Select.Count() == 0)
            {
                options.Filter = null;
                options.Take = 0;
                options.Skip = 0;
                var dtoQryResult = await FilterAsDtoAsync<T, TDto>(context, _mapper, qryResult, options, uow);
                dtoQryResult.totalCount = qryResult.totalCount;
                return dtoQryResult;
            }
            else return qryResult;
        }

        private async static Task<LoadResult> FilterAsDtoAsync<T, TDto>(DbContext context, IMapper _mapper, LoadResult loadedData, DataSourceLoadOptions loadOptions, IActiveUnitOfWork uow) where T : class
        {
            //Se precisar essa função conforme : https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/367
            //ela nao está  funcionando corretamente. Provelmente pela adicão do Zero os filtros automaticos que devem ocorrer apos a consuta
            //Foi tentado desabilitar com do Disbled filter da Unit mas nao desabilitou, tera que ser verificado

            //Ver tambeme esse Link https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/338

            Expression<Func<TDto, bool>> lambda = GetDtoByIdPredicate<T, TDto>(context, loadedData);

            using (uow.DisableFilter(new string[] { AbpDataFilters.MustHaveTenant, AbpDataFilters.MayHaveTenant, AbpDataFilters.SoftDelete }))
            {
                var returnData = await AspNet.DataSourceLoader.LoadAsync(context.Set<T>().ProjectTo<TDto>(_mapper.ConfigurationProvider).Where(lambda), loadOptions);
                return returnData;
            }
        }



        private static Expression<Func<TDto, bool>> GetDtoByIdPredicate<T, TDto>(DbContext context, LoadResult loadedData) where T : class
        {
            var pkey = context.Model.FindEntityType(typeof(T).FullName).FindPrimaryKey().Properties.Select(n => n.Name).Single();
            var pKeyExp = Expression.Parameter(typeof(T));
            var pKeyProperty = Expression.PropertyOrField(pKeyExp, pkey);
            var keySelector = Expression.Lambda<Func<T, Guid>>(pKeyProperty, pKeyExp).Compile();

            List<Guid> idList = loadedData.data.Cast<T>().Select(keySelector).ToList();

            var pKeyExpDto = Expression.Parameter(typeof(TDto));
            var pKeyPropertyDto = Expression.PropertyOrField(pKeyExpDto, pkey);
            var method = idList.GetType().GetMethod("Contains");
            var call = Expression.Call(Expression.Constant(idList), method, pKeyPropertyDto);
            var lambda = Expression.Lambda<Func<TDto, bool>>(call, pKeyExpDto);
            return lambda;
        }
    }
}
