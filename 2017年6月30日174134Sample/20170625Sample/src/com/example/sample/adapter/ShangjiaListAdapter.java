package com.example.sample.adapter;

import java.util.ArrayList;
import java.util.HashMap;

import com.example.sample.R;

import android.content.Context;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

public class ShangjiaListAdapter  extends BaseAdapter{

	private Context context;
	private ArrayList<HashMap<String,Object>> data;

	
	public ShangjiaListAdapter(Context context,ArrayList<HashMap<String,Object>> item){
		this.context = context;
		this.data = item;
	}
	
	@Override
	public int getCount() {
		// TODO Auto-generated method stub
		return data.size();
	}

	@Override
	public Object getItem(int position) {
		// TODO Auto-generated method stub
		return data.get(position);
	}

	@Override
	public long getItemId(int position) {
		// TODO Auto-generated method stub
		return position;
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {
		DataList dl = new DataList();  
		Log.d("48行shangjialistadapter", "48行");
		convertView = LayoutInflater.from(context).inflate(R.layout.shangjia_item, null);
		Log.d("49行shangjialistadapter", "49行");
		dl.iv_name = (ImageView) convertView.findViewById(R.id.iv_name);
		Log.d("50行shangjialistadapter", "50行");
//	    dl.iv_shangjia_image = (ImageView) convertView.findViewById(R.id.iv_shangjia_image);
		dl.tv_shangjia_name = (TextView) convertView.findViewById(R.id.tv_shangjia_name);	
		dl.tv_youhuijia = (TextView) convertView.findViewById(R.id.tv_youhuijia);
//		dl.tv_price = (TextView) convertView.findViewById(R.id.tv_price);
//		dl.tv_qi = (TextView) convertView.findViewById(R.id.tv_qi);
		dl.tv_address = (TextView) convertView.findViewById(R.id.tv_address);
//		dl.tv_category = (TextView) convertView.findViewById(R.id.tv_category);
//		dl.tv_distance = (TextView) convertView.findViewById(R.id.tv_distance);
		
		dl.tv_shangjia_name.setText(data.get(position).get("tv_shangjia_name").toString());	Log.d("60行shangjialistadapter", "60行");
//		dl.tv_qi.setText(data.get(position).get("tv_qi").toString());   Log.d("61行shangjialistadapter", "61行");
		dl.tv_address.setText(data.get(position).get("tv_address").toString());Log.d("63行shangjialistadapter", "63行");
//		if(   !dl.tv_shangjia_name.getText().toString().contains("急")  )
//		{
//			dl.iv_shangjia_image.setVisibility(View.GONE); 
//		}
		Log.d("67行shangjialistadapter", "67行");
		return convertView;
	}

	private class DataList{
		public TextView tv_shangjia_name,//客户名称
						tv_youhuijia,//优惠价
						tv_price,//价格
						tv_qi,//起
						tv_category,//类别
						tv_address,//客户地址
						tv_distance;//距离
		
		public ImageView iv_shangjia_image,//急
						 iv_name;//客户图片
		
	}
	
}
