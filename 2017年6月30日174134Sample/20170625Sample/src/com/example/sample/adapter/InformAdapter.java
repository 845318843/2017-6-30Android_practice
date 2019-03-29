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
 *  2017��6��29��20:41:38  ���Ͻ��ʼ� ��Ϣ
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
		Log.d("48��InformAdapter", "53��");
		convertView = LayoutInflater.from(context).inflate(R.layout.inform_item, null);
		Log.d("InformAdapter", "56��");
		dl.TextView_Titel =   (TextView) convertView.findViewById(R.id.TextView_inform_title);	
		Log.d("InformAdapter", "57��");
		dl.TextView_Content = (TextView) convertView.findViewById(R.id.TextView_inform_Content);	
		Log.d("InformAdapter", "59��");
		dl.TextView_Titel.setText(data.get(position).get("TextView_inform_title").toString());
		Log.d("InformAdapter", "61��");
		dl.TextView_Content.setText(data.get(position).get("TextView_inform_Content").toString());
		Log.d("InformAdapter", "63��");
		return convertView;
	}

	private class DataList{
		public TextView TextView_Time,//����ʱ��
		TextView_Titel,//���ѱ���
		TextView_Content;//���ѵ�����	 
	}
}
