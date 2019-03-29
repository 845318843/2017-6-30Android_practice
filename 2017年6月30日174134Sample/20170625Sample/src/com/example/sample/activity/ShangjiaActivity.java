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
	private List<MessageLess> messageList = new ArrayList<MessageLess>(); // 消息列表

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub	 
		super.onCreate(savedInstanceState);
		setContentView(R.layout.second);
		Log.d("SanjiaActivity", "外观设置完成");		
		Intent data = getIntent();
		e_user =  (E_User) data.getSerializableExtra("e_user");	     
		lv_shangjia = (ListView) findViewById(R.id.lv_shangjia);
		
		try{
			String[] strArray = null;
			strArray = e_user.user_Address.split("\\|"); //拆分字符为"|" ,然后把结果交给数组strArray 
			Region=strArray[0];
			industry=strArray[1];
			Log.d("sanjia46?", String.valueOf(e_user.user_Address));  
			Log.d("sanjia47?", String.valueOf(Region));  
			Log.d("sanjia48?", String.valueOf(industry));  
		}
		catch(Exception e ){
			Log.d("sanjia", "遇到了一点问题");  
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
				// 在这里进行UI操作，将结果显示到界面上
				ShangjiaListAdapter adapter = new ShangjiaListAdapter(ShangjiaActivity.this, response);
				Log.d("51行loginSoapObject", "51行");
				lv_shangjia.setAdapter(adapter);
				Log.d("53行loginSoapObject", "53行");
				break;
			case 'S':  				 
				getData(Region,industry);
			}
		}
	};

	private void initPopupWindow() {
		/**开启一个新线程*/  
		new Thread(){  
			public void run() { 
				for(int i=0 ;i<1 ;i++)
				{
					/**每睡眠1秒后发送Message给Handler处理*/        
					try {  						
						Message msg=new Message();  
						msg.what='S';//设置Message附带的参数  
						handler.sendMessage(msg);//发送Message对象给Handler  
						Log.d("70行loginSoapObject", "这是第"+String.valueOf(i)+"次");
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
	 * 按条件搜索
	 * @param text
	 * @param text2
	 */
	private void getData(final String region, final String industry) {
		// 开启线程来发起网络请求
		new Thread(new Runnable() {
			@Override
			public void run() {
				Log.i("shangjiaactivity类 欢迎到 69行","69wj");
				itemList.clear();
				Log.i("shangjiaactivity类 欢迎到 73行","73wj");
				List<MessageLess> listms = new ArrayList<MessageLess>(); 

				Log.i("shangjiaactivity类 欢迎到 134行","debug");
				listms=MessageUtils.getMessageENModels(region,industry);
				Log.i("shangjiaactivity类 欢迎到 136行",String.valueOf( listms.size() ) );
				messageList.clear();
				messageList = listms;
				//FillTextView(listms);
				for (int i = 0; i < listms.size(); i++) 
				{
					Log.i("欢迎到 85行","85");
					HashMap<String, Object> items = new HashMap<String, Object>();Log.i("欢迎到 86行","86");
					items.put("tv_shangjia_name", listms.get(i).message_Title.toString());Log.i("欢迎到 87行","87");
					items.put("tv_qi", listms.get(i).message_Creator.toString());Log.i("欢迎到 88行","88");
					//					items.put("tv_address", listms.get(i)._message_Region.toString()+listms.get(i)._message_Time.getDate()   );
					items.put("tv_address", listms.get(i).message_Region.toString() );
					Log.i("欢迎到 90行","90");
					itemList.add(items);Log.i("欢迎到 91行","91");	
				}			
				Message message = new Message();Log.i("欢迎到 92行","92");
				message.what = 'M';
				// 将服务器返回的结果存放到Message中
				message.obj = itemList ;Log.i("欢迎到 95行","95");
				handler.sendMessage(message);Log.i("欢迎到 96行","96");
			}
		}).start();

	}



}
