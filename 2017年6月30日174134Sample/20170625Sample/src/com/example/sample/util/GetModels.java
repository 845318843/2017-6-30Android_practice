package com.example.sample.util;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.PropertyInfo;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import android.util.Log;

public class GetModels {

	/**     2017��6��28��20:27:44�ϳ�  ����  ����json ����json
	 *  ��¼��֤
	 * @param username
	 * @param password
	 * @return

	public static Boolean getLoginstatus(String username, String password) {
		PropertyInfo[] propertyInfos = new PropertyInfo[2];
		propertyInfos[0] = new PropertyInfo();
		propertyInfos[0].setName("username");
		propertyInfos[0].setValue(username);

		propertyInfos[1] = new PropertyInfo();
		propertyInfos[1].setName("password");
		propertyInfos[1].setValue(password);
		String methodName = "ModelLogin";

		String status =String.valueOf(getObject(methodName,propertyInfos)); //loginsoapobject.getProperty("string").toString();
		if( status.contains("true") )
		{
			return true;
		}
		else
		{
			return false;
		}		
	}  */

	 /**  ��¼��֤������json
	 * @param username
	 * @param password
	 * @return
	 */
	public static String getLoginstatus(String jsonuserin) {
		PropertyInfo[] propertyInfos = new PropertyInfo[1];
		propertyInfos[0] = new PropertyInfo();
		propertyInfos[0].setName("jsonuserin");
		propertyInfos[0].setValue(jsonuserin);

		String methodName = "Login";

		String status =String.valueOf(getObject(methodName,propertyInfos)); //loginsoapobject.getProperty("string").toString();	 
		return status;
	}

    /**  ��ȡ  ֪ͨlist  ������ json
     *  
     * @param jsonin
     * @return
     */
	public static String getHS_Inform(String jsonuserin) {
		PropertyInfo[] propertyInfos = new PropertyInfo[1];
		propertyInfos[0] = new PropertyInfo();
		propertyInfos[0].setName("jsonuserin");
		propertyInfos[0].setValue(jsonuserin);

		String methodName = "HS_Inform";

		String status =String.valueOf(getObject(methodName,propertyInfos));   
		return status;
	}  



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

	/** 
	 * ��webservice����Զ�����ݿ����� 
	 *  
	 * @param methodName 
	 *            ������ 
	 * @param propertyInfos 
	 *            ���� 
	 * @return 
	 */   
	public static Object getObject(String methodName, PropertyInfo[] propertyInfos) {  
		Log.i("getmodels �� ��ӭ�� 116��","116");
		Object object = GetWebServiceData(NAMESPACE, webserviceUrl + "/" + pageName, NAMESPACE + methodName, methodName,  
				propertyInfos);  Log.i("getmodels �� ��ӭ�� 116��","11116");
				Log.i("getmodels �� ��ӭ�� 119��",String.valueOf(object) );
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
	private static  Object GetWebServiceData(final String iNameSpace,  
			final String iWebserviceURL,final String iSoapAction,final String iMethodName,  
			final PropertyInfo[] iPropertyInfo)                                { 

		Log.i("getmodels �� ��ӭ�� 135��","202");
		Object result = null;  
		try {  
			Log.i("getmodels �� ��ӭ�� 138��","����try205");
			SoapObject rpc = new SoapObject(iNameSpace, iMethodName);  
			for (int i = 0; i < iPropertyInfo.length; i++) {  
				rpc.addProperty(iPropertyInfo[i]);  
			}  
			Log.i("getmodels �� ��ӭ�� 143��","����try210");
			SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(  
					SoapEnvelope.VER12);  
			envelope.bodyOut = rpc;  

			envelope.dotNet = true;  
			envelope.setOutputSoapObject(rpc);  
			Log.i("getmodels �� ��ӭ�� 150��","����try217");
			HttpTransportSE ht = new HttpTransportSE(iWebserviceURL, 5000);    
			Log.i("getmodels �� ��ӭ�� 151��","����try220");
			ht.debug = true;   
			Log.i("getmodels �� ��ӭ�� 153��",iSoapAction);
			Log.i("getmodels �� ��ӭ�� 153��",envelope.enc);
			ht.call(iSoapAction, envelope);   
			Log.i("getmodels �� ��ӭ�� 153��","����try224");
			Log.i("getmodels �� ��ӭ�� 154��","����try");
			result = envelope.getResponse();  
			Log.i("getmodels �� ��ӭ�� 146��","����try227");
		} catch (Exception e) {  
			//            Toast.makeText( getApplicationContext(), "���ӷ�����ʧ��,�����������ã�", Toast.LENGTH_SHORT)  
			//            .show();  
			Log.e("getmodels 152��231", e.getMessage());
		}

		return result;  
	}



}
