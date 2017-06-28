using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using Android.Content;

namespace PreciosGas
{
    [Activity(Label = "PreciosGas", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        public static Context context;
        public static List<UserInfo> UserInfoList = new List<UserInfo>();
        public static ListView ListView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
            SetContentView(Resource.Layout.Main);
            ListView = FindViewById<ListView>(Resource.Id.listView);
            GetList list = new GetList();
            list.Execute();
            
        }


        public class GetList : AsyncTask
        {
       
            Context con;
            protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
            {
                //toma la informacion
                System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
                var _WebApiUrl = string.Format("https://URL/api/Account/Profile");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage messge = client.GetAsync(_WebApiUrl).Result;
                var Return_EventList = messge.Content.ReadAsStringAsync().Result;
                var EventList = JsonConvert.DeserializeObject<List<UserInfo>>(Return_EventList);
                foreach (var data in EventList)
                {
                
                   UserInfoList.Add(data);
            
                }
                return true;
            }


            protected override void OnPreExecute()
            {
                base.OnPreExecute();
            }
            protected override void OnPostExecute(Java.Lang.Object result)
            {
                base.OnPostExecute(result);
           
                ListView.Adapter = new UserInfoListAdapter(context, UserInfoList);
            }
        }
    }
}

