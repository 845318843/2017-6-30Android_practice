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
	private List<HS_Inform> informList = new ArrayList<HS_Inform>(); // ��Ϣ�б�
	
	//�ҵ����ϽǷ���
	 private ImageView ImageView_back;
	//�ҵ����Ͻ����
     private LinearLayout LinearLayout_allclean;
	
	
	@Override   /* �󶨵������ ȫд�ڴ�  */
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.inform);		
		Log.d("InformA", "����������");		
		Intent data = getIntent();
		e_user =  (E_User) data.getSerializableExtra("e_user");	 
		ListView_inform = (ListView) findViewById(R.id.ListView_Informlist);
    
		initPopupWindow();
		
		
		ImageView_back = (ImageView) findViewById(R.id.ImageView_back);
		ImageView_back.setOnClickListener(this);
		LinearLayout_allclean =  (LinearLayout) findViewById(R.id.LinearLayout_allclean);
		LinearLayout_allclean.setOnClickListener(this);
	}
	@Override  /* ������� ȫд�ڴ�  */
	public void onClick(View v) {
		switch (v.getId()) {
		/* ���� */
		case R.id.ImageView_back:
			 finish();
			break;
		/* ��� */
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
				// ���������UI�������������ʾ��������
				InformAdapter adapter = new InformAdapter(InformActivity.this, response);
				Log.d("InformActivity 59", "adapter �������");
				ListView_inform.setAdapter(adapter);
				Log.d("InformActivity 61", "setadapter ���");
				break;
			case 'S':  				 
				getData(e_user);
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
	private void getData(final E_User e_user) {
		// �����߳���������������
		new Thread(new Runnable() {
			@Override
			public void run() {
				Log.i("shangjiaactivity�� ��ӭ�� 69��","69wj");
				itemList.clear();
				Log.i("shangjiaactivity�� ��ӭ�� 73��","73wj");
				List<HS_Inform> listms = new ArrayList<HS_Inform>(); 
				Log.i("shangjiaactivity�� ��ӭ�� 134��","debug");			 
				listms=HS_InformUtils.getInformModels(e_user);
				Log.i("shangjiaactivity�� ��ӭ�� 136��",String.valueOf( listms.size() ) );
				informList.clear();
				informList = listms;
				//FillTextView(listms);
				for (int i = 0; i < listms.size(); i++) 
				{
					Log.i("��ӭ�� 85��","85");
					HashMap<String, Object> items = new HashMap<String, Object>();Log.i("��ӭ�� 86��","86");
					items.put("TextView_inform_title", listms.get(i).inform_Title.toString());Log.i("��ӭ�� 87��","87");
					items.put("TextView_inform_Content", listms.get(i).inform_Content.toString());Log.i("��ӭ�� 88��","88");			 
					itemList.add(items);Log.i("��ӭ�� 91��","91");	
				}			
				Message message = new Message();Log.i("��ӭ�� 92��","92");
				message.what = 'M';
				// �����������صĽ����ŵ�Message��
				message.obj = itemList ; 
				handler.sendMessage(message); 
			}
		}).start();
	}

	
}
