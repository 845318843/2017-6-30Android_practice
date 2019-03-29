package com.example.sample.activity;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import com.example.sample.R;
import com.example.sample.adapter.InformAdapter;
import com.example.sample.adapter.ShangjiaListAdapter;
import com.example.sample.bean.E_User;
import com.example.sample.bean.HS_Inform;
import com.example.sample.bean.MessageLess;
import com.example.sample.util.HS_InformUtils;
import com.example.sample.util.MessageUtils;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.util.Log;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.ListView;



public class InformActivity  extends Activity implements OnClickListener{

	private E_User e_user=null;

	private   String e_user_account;
	private   ListView 	ListView_inform;
	private  ArrayList<HashMap<String, Object>> itemList= new ArrayList<HashMap<String, Object>>();
	private List<HS_Inform> informList = new ArrayList<HS_Inform>(); // 消息列表
	
	//我的左上角返回
	 private ImageView ImageView_back;
	//我的右上角清空
     private LinearLayout LinearLayout_allclean;
	
	
	@Override   /* 绑定点击监听 全写在此  */
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.inform);		
		Log.d("InformA", "外观设置完成");		
		Intent data = getIntent();
		e_user =  (E_User) data.getSerializableExtra("e_user");	 
		ListView_inform = (ListView) findViewById(R.id.ListView_Informlist);
    
		initPopupWindow();
		
		
		ImageView_back = (ImageView) findViewById(R.id.ImageView_back);
		ImageView_back.setOnClickListener(this);
		LinearLayout_allclean =  (LinearLayout) findViewById(R.id.LinearLayout_allclean);
		LinearLayout_allclean.setOnClickListener(this);
	}
	@Override  /* 点击监听 全写在此  */
	public void onClick(View v) {
		switch (v.getId()) {
		/* 后退 */
		case R.id.ImageView_back:
			 finish();
			break;
		/* 清空 */
		case R.id.LinearLayout_allclean:
			ArrayList<HashMap<String,Object>> item=new ArrayList<HashMap<String,Object>> ();
			InformAdapter adapter = new InformAdapter(InformActivity.this,item);
			ListView_inform.setAdapter(adapter);
			break;	 
		default:
			break;
		}		
	}
	
	
	private  Handler handler = new Handler() {
		public void handleMessage(Message msg) {
			switch (msg.what) {
			case 'M':
				@SuppressWarnings("unchecked")
				ArrayList<HashMap<String, Object>> response = (ArrayList<HashMap<String, Object>>) msg.obj;
				// 在这里进行UI操作，将结果显示到界面上
				InformAdapter adapter = new InformAdapter(InformActivity.this, response);
				Log.d("InformActivity 59", "adapter 构造完成");
				ListView_inform.setAdapter(adapter);
				Log.d("InformActivity 61", "setadapter 完成");
				break;
			case 'S':  				 
				getData(e_user);
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
	private void getData(final E_User e_user) {
		// 开启线程来发起网络请求
		new Thread(new Runnable() {
			@Override
			public void run() {
				Log.i("shangjiaactivity类 欢迎到 69行","69wj");
				itemList.clear();
				Log.i("shangjiaactivity类 欢迎到 73行","73wj");
				List<HS_Inform> listms = new ArrayList<HS_Inform>(); 
				Log.i("shangjiaactivity类 欢迎到 134行","debug");			 
				listms=HS_InformUtils.getInformModels(e_user);
				Log.i("shangjiaactivity类 欢迎到 136行",String.valueOf( listms.size() ) );
				informList.clear();
				informList = listms;
				//FillTextView(listms);
				for (int i = 0; i < listms.size(); i++) 
				{
					Log.i("欢迎到 85行","85");
					HashMap<String, Object> items = new HashMap<String, Object>();Log.i("欢迎到 86行","86");
					items.put("TextView_inform_title", listms.get(i).inform_Title.toString());Log.i("欢迎到 87行","87");
					items.put("TextView_inform_Content", listms.get(i).inform_Content.toString());Log.i("欢迎到 88行","88");			 
					itemList.add(items);Log.i("欢迎到 91行","91");	
				}			
				Message message = new Message();Log.i("欢迎到 92行","92");
				message.what = 'M';
				// 将服务器返回的结果存放到Message中
				message.obj = itemList ; 
				handler.sendMessage(message); 
			}
		}).start();
	}

	
}
