package com.example.sample.activity;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.PropertyInfo;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import com.example.sample.R;

import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.app.Activity;
import android.util.Log;
import android.view.Menu;
import android.view.View;

import android.widget.Button;
import android.widget.TextView;
import android.view.View.OnClickListener;

public class MainActivity extends Activity implements OnClickListener {

	TextView tvMessage;

	public static final int SHOW_RESPONSE = 0;
	private Button sendRequest;
	private TextView responseText;
	private Handler handler = new Handler() {
		public void handleMessage(Message msg) {
			switch (msg.what) {
			case SHOW_RESPONSE:
				String response = (String) msg.obj;
				// ���������UI�������������ʾ��������
				tvMessage.setText(response);
			}
		}
	};

	
	Button  callhelloword;	 
	/** 
	 * webservices�����ռ� 
	 */  
	public static final String NAMESPACE = "http://tempuri.org/";  
	/** 
	 * ҳ������ 
	 */  
	public static String pageName = "WebService1.asmx";  

	/** 
	 * webservices��ַ 
	 */  
	public static String webserviceUrl = "http://172.16.33.134:5057/";  


	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		callhelloword = (Button)findViewById(R.id.btnHelloWorld);
		tvMessage = (TextView)findViewById(R.id.textView1);

		callhelloword.setOnClickListener(this);
	} 

	@Override
	public void onClick(View v)  {
		SendLogin();
	}



	private void SendLogin() {
		// �����߳���������������
		new Thread(new Runnable() {
			@Override
			public void run() {

				PropertyInfo[] propertyInfos = new PropertyInfo[2];
				propertyInfos[0] = new PropertyInfo();
				propertyInfos[0].setName("username");
				propertyInfos[0].setValue("123456");

				propertyInfos[1] = new PropertyInfo();
				propertyInfos[1].setName("password");
				propertyInfos[1].setValue("123123");

				String methodName = "ModelLogin"; 
				String status =String.valueOf(getObject(methodName,propertyInfos));		
				Log.d("��78��",status);
				if( status.contains("true") )
				{
					Message message = new Message();
					message.what = SHOW_RESPONSE;
					// �����������صĽ����ŵ�Message��
					message.obj = "true";
					handler.sendMessage(message);
				}
				else
				{
					Message message = new Message();
					message.what = SHOW_RESPONSE;
					// �����������صĽ����ŵ�Message��
					message.obj = "false";
					handler.sendMessage(message);
				}		
			}
		}).start();
	}


	private Object getObject(String methodName, PropertyInfo[] propertyInfos) {
		Object object = GetWebServiceData(NAMESPACE, webserviceUrl + "/" + pageName, NAMESPACE + methodName, methodName,  
				propertyInfos);  
		return object;
	}



	/**
	 * 
	 * @param �����ռ�
	 * @param iWebserviceURL
	 * @param iSoapAction
	 * @param iMethodName
	 * @param iPropertyInfo
	 * @return
	 */
	private static Object  GetWebServiceData(String iNameSpace,  
			String iWebserviceURL, String iSoapAction, String iMethodName,  
			PropertyInfo[] iPropertyInfo) { 

		Object result = null;  
		try {  

			SoapObject rpc = new SoapObject(iNameSpace, iMethodName);  
			for (int i = 0; i < iPropertyInfo.length; i++) {  
				rpc.addProperty(iPropertyInfo[i]);  
			}  

			SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(  
					SoapEnvelope.VER12);  
			envelope.bodyOut = rpc;  

			envelope.dotNet = true;  
			envelope.setOutputSoapObject(rpc);  

			HttpTransportSE ht = new HttpTransportSE(iWebserviceURL, 5000);    
			ht.debug = true;   

			ht.call(iSoapAction, envelope);    

			result = envelope.getResponse();  

		} catch (Exception e) {  
			//            Toast.makeText( getApplicationContext(), "���ӷ�����ʧ��,�����������ã�", Toast.LENGTH_SHORT)  
			//            .show();  
			Log.d("��142��","���ӷ�����ʧ��,�����������ã�");  
		}  

		return result;  
	}
}

