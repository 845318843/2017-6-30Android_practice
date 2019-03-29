package com.example.sample.activity;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.util.Log;
import android.widget.ListView;

import com.example.sample.R;
import com.example.sample.adapter.ShangjiaListAdapter;
import com.example.sample.bean.E_User;
import com.example.sample.bean.MessageEN;
import com.example.sample.bean.MessageLess;
import com.example.sample.util.GetModels;
import com.example.sample.util.MessageUtils;

public class ShangjiaActivity extends Activity{

	private E_User e_user=null;

	private   String Region;
	private   String industry;
	private   ListView lv_shangjia;
	//	private   ListView  listView ;
	private  ArrayList<HashMap<String, Object>> itemList= new ArrayList<HashMap<String, Object>>();
	private List<MessageLess> messageList = new ArrayList<MessageLess>(); // ��Ϣ�б�

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub	 
		super.onCreate(savedInstanceState);
		setContentView(R.layout.second);
		Log.d("SanjiaActivity", "����������");		
		Intent data = getIntent();
		e_user =  (E_User) data.getSerializableExtra("e_user");	     
		lv_shangjia = (ListView) findViewById(R.id.lv_shangjia);
		
		try{
			String[] strArray = null;
			strArray = e_user.user_Address.split("\\|"); //����ַ�Ϊ"|" ,Ȼ��ѽ����������strArray 
			Region=strArray[0];
			industry=strArray[1];
			Log.d("sanjia46?", String.valueOf(e_user.user_Address));  
			Log.d("sanjia47?", String.valueOf(Region));  
			Log.d("sanjia48?", String.valueOf(industry));  
		}
		catch(Exception e ){
			Log.d("sanjia", "������һ������");  
		}
		finally{
			Region="";industry="";
		}
		initPopupWindow();
	};

	private  Handler handler = new Handler() {
		public void handleMessage(Message msg) {
			switch (msg.what) {
			case 'M':
				@SuppressWarnings("unchecked")
				ArrayList<HashMap<String, Object>> response = (ArrayList<HashMap<String, Object>>) msg.obj;
				// ���������UI�������������ʾ��������
				ShangjiaListAdapter adapter = new ShangjiaListAdapter(ShangjiaActivity.this, response);
				Log.d("51��loginSoapObject", "51��");
				lv_shangjia.setAdapter(adapter);
				Log.d("53��loginSoapObject", "53��");
				break;
			case 'S':  				 
				getData(Region,industry);
			}
		}
	};

	private void initPopupWindow() {
		/**����һ�����߳�*/  
		new Thread(){  
			public void run() { 
				for(int i=0 ;i<1 ;i++)
				{
					/**ÿ˯��1�����Message��Handler����*/        
					try {  						
						Message msg=new Message();  
						msg.what='S';//����Message�����Ĳ���  
						handler.sendMessage(msg);//����Message�����Handler  
						Log.d("70��loginSoapObject", "���ǵ�"+String.valueOf(i)+"��");
						Thread.sleep(10000);  					
					} catch (InterruptedException e) {  
						// TODO Auto-generated catch block  
						e.printStackTrace();  
					}  
				}  
			}
		}.start();  
	}
	/**
	 * ����������
	 * @param text
	 * @param text2
	 */
	private void getData(final String region, final String industry) {
		// �����߳���������������
		new Thread(new Runnable() {
			@Override
			public void run() {
				Log.i("shangjiaactivity�� ��ӭ�� 69��","69wj");
				itemList.clear();
				Log.i("shangjiaactivity�� ��ӭ�� 73��","73wj");
				List<MessageLess> listms = new ArrayList<MessageLess>(); 

				Log.i("shangjiaactivity�� ��ӭ�� 134��","debug");
				listms=MessageUtils.getMessageENModels(region,industry);
				Log.i("shangjiaactivity�� ��ӭ�� 136��",String.valueOf( listms.size() ) );
				messageList.clear();
				messageList = listms;
				//FillTextView(listms);
				for (int i = 0; i < listms.size(); i++) 
				{
					Log.i("��ӭ�� 85��","85");
					HashMap<String, Object> items = new HashMap<String, Object>();Log.i("��ӭ�� 86��","86");
					items.put("tv_shangjia_name", listms.get(i).message_Title.toString());Log.i("��ӭ�� 87��","87");
					items.put("tv_qi", listms.get(i).message_Creator.toString());Log.i("��ӭ�� 88��","88");
					//					items.put("tv_address", listms.get(i)._message_Region.toString()+listms.get(i)._message_Time.getDate()   );
					items.put("tv_address", listms.get(i).message_Region.toString() );
					Log.i("��ӭ�� 90��","90");
					itemList.add(items);Log.i("��ӭ�� 91��","91");	
				}			
				Message message = new Message();Log.i("��ӭ�� 92��","92");
				message.what = 'M';
				// �����������صĽ����ŵ�Message��
				message.obj = itemList ;Log.i("��ӭ�� 95��","95");
				handler.sendMessage(message);Log.i("��ӭ�� 96��","96");
			}
		}).start();

	}



}
