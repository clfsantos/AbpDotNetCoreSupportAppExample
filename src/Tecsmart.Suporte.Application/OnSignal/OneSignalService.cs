using System;
using System.Collections.Generic;
using Tecsmart.Suporte.OnSignal.Notifications;

namespace Tecsmart.Suporte.OnSignal
{
    public class OneSignalService
    {
        const string ApiKey = "YTgyZjNjZWEtODgzZS00YmUyLTlmZGEtNjNhY2Q0ZjhmZDEw";

        public static void SendPush(long idUsuario, string titulo, string texto, string url)
        {
            try
            {
                //Filtro 
                NotificationFilterField Filtro = new NotificationFilterField();
                Filtro.Field = NotificationFilterFieldTypeEnum.Tag;
                Filtro.Key = "idUsuario";
                Filtro.Relation = "=";
                Filtro.Value = idUsuario.ToString();

                var client = new OneSignalClient(ApiKey);
                var options = new NotificationCreateOptions
                {
                    AppId = new Guid("61880d20-6980-45c4-a865-7a67306beeeb"),

                    //Adicionar Data para entrega, filtros e tals
                    Filters = new List<INotificationFilter>()
                    {
                       Filtro
                    }

                    // SendAfter = DataHora.AddMinutes(-5),   

                    //SendAfter = SendFormat,
                    //TimeToLive = 900,
                };
                options.Headings.Add(LanguageCodes.English, titulo);
                options.Contents.Add(LanguageCodes.English, texto);
                options.Url = url;
                var result = client.Notifications.Create(options);                

            }
            catch(Exception ex)
            {
            }
        }

        public static void SendPushSuporte(string titulo, string texto, string url)
        {
            try
            {
                //Filtro 
                NotificationFilterField Filtro = new NotificationFilterField();
                Filtro.Field = NotificationFilterFieldTypeEnum.Tag;
                Filtro.Key = "Suporte";
                Filtro.Relation = "=";
                Filtro.Value = "Suporte";

                var client = new OneSignalClient(ApiKey);
                var options = new NotificationCreateOptions
                {
                    AppId = new Guid("61880d20-6980-45c4-a865-7a67306beeeb"),

                    //Adicionar Data para entrega, filtros e tals
                    Filters = new List<INotificationFilter>()
                    {
                       Filtro
                    }

                    // SendAfter = DataHora.AddMinutes(-5),   

                    //SendAfter = SendFormat,
                    //TimeToLive = 900,
                };
                options.Headings.Add(LanguageCodes.English, titulo);
                options.Contents.Add(LanguageCodes.English, texto);
                options.Url = url;
                var result = client.Notifications.Create(options);

            }
            catch (Exception ex)
            {
            }
        }

    }
}
