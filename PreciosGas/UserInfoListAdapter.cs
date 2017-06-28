using System;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Android.Content;

namespace PreciosGas
{
    class UserInfoListAdapter : BaseAdapter<UserInfo>
    {
        private List<UserInfo> mItem = new List<UserInfo>();
        private Context context;

        
        public UserInfoListAdapter(Context mcontext, List<UserInfo> mItems)
        {
            mItem.Clear();
            mItem = mItems;
            context = mcontext;
            this.NotifyDataSetChanged();
        }
        

        public override UserInfo this[int position]
        {
            get
            {
                return mItem[position];
            }
        }
           

        public override int Count
        {
            get
            {
                return mItem.Count;
            }
        }

        public Context MContext
        {
            get;
            private set;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View listitem = convertView;
            listitem = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ListViewDesign, parent, false);
            TextView TxtName = listitem.FindViewById<TextView>(Resource.Id.TxtName);
            TextView TxtNumber = listitem.FindViewById<TextView>(Resource.Id.TxtNumber);
            TxtName.Text = mItem[position].firstname;
            TxtNumber.Text = mItem[position].contact_no;
            listitem.Click += (object sender, EventArgs e) => {
                Toast.MakeText(parent.Context, "Clicked " + mItem[position].firstname, ToastLength.Long).Show();
            };
            return listitem;
        }
    }
}