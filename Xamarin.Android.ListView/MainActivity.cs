using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System.Collections.Generic;
using Android.Content;
using System;
using List = global::Android.Widget.ListView;

namespace Xamarin.Android.ListView
{
	[Activity(Label = "Xamarin.Android.ListView", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Main);

			List lst = FindViewById<List>(Resource.Id.lst);

			List<string> Data = new List<string>();
			Data.Add("Prosto GG 1");
			Data.Add("Prosto GG 2");
			Data.Add("Prosto GG 3");
			Data.Add("Prosto GG 4");
			Data.Add("Prosto GG 5");
			Data.Add("Prosto GG 6");
			Data.Add("Prosto GG 7");
			Data.Add("Prosto GG 8");
			Data.Add("Prosto GG 9");
			Data.Add("Prosto GG 10");
			Data.Add("Prosto GG 11");
			Data.Add("Prosto GG 12");
			Data.Add("Prosto GG 13");
			Data.Add("Prosto GG 14");
			
			CustomAdapter cst = new CustomAdapter(Data, this);
			lst.Adapter = cst;
		}
	}


	class CustomAdapter : BaseAdapter<string>
	{
		Dialog alertDialog;
		int count = 0;
		List<string> _Items;
		Context _context;
		public CustomAdapter(List<string> Items, Context context)
		{
			this._Items = Items;
			this._context = context;
		}

		#region implemented abstract members of BaseAdapter
		public override long GetItemId(int position)
		{
			return position;
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			ServiceViewHolder holder = null;

			var view = convertView;

			if (view == null)
			{
				////this is part of ViewHolder pattern,new istance of ViewHolder
				holder = new ServiceViewHolder();
				view = LayoutInflater.From(_context).Inflate(Resource.Layout.ListItem, null);
				holder.Txt = view.FindViewById<TextView>(Resource.Id.txt);
				holder.PushME = view.FindViewById<Button>(Resource.Id.Push);
				//put your handler here,in this block of code,like this
				holder.PushME.Click += (sender, e) =>
					{
						var Btn = (Button)sender;
						int RealPos = (int)Btn.Tag;
						Toast.MakeText(_context, String.Format("Item {0} has been clicked", _Items[RealPos]), ToastLength.Short).Show();
					};
				view.Tag = holder;
			}
			else
			{
				holder = view.Tag as ServiceViewHolder;
			}
			holder.Txt.Text = _Items[position];
			holder.PushME.Tag = position;
			return view;
		}
		public override int Count
		{
			get
			{
				return _Items.Count;
			}
		}
		#endregion
		#region implemented abstract members of BaseAdapter
		public override string this[int index]
		{
			get
			{
				return _Items[index];
			}
		}
		#endregion

	}

	public class ServiceViewHolder : Java.Lang.Object
	{
		public Button PushME { get; set; }

		public TextView Txt { get; set; }

	}
}

