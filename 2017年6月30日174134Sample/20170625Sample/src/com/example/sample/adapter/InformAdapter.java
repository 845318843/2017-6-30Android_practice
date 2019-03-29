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

/**
 *  2017年6月29日20:41:38  右上角邮件 消息
 * @author Administrator
 *
 */
public class InformAdapter  extends BaseAdapter{

	private Context context;
	private ArrayList<HashMap<String,Object>> data;


	public InformAdapter(Context context,ArrayList<HashMap<String,Object>> item){
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
	public View getView(int position, View convertView, ViewGroup parent){
		DataList dl = new DataList();  
		Log.d("48行InformAdapter", "53行");
		convertView = LayoutInflater.from(context).inflate(R.layout.inform_item, null);
		Log.d("InformAdapter", "56行");
		dl.TextView_Titel =   (TextView) convertView.findViewById(R.id.TextView_inform_title);	
		Log.d("InformAdapter", "57行");
		dl.TextView_Content = (TextView) convertView.findViewById(R.id.TextView_inform_Content);	
		Log.d("InformAdapter", "59行");
		dl.TextView_Titel.setText(data.get(position).get("TextView_inform_title").toString());
		Log.d("InformAdapter", "61行");
		dl.TextView_Content.setText(data.get(position).get("TextView_inform_Content").toString());
		Log.d("InformAdapter", "63行");
		return convertView;
	}

	private class DataList{
		public TextView TextView_Time,//提醒时间
		TextView_Titel,//提醒标题
		TextView_Content;//提醒的内容	 
	}
}
