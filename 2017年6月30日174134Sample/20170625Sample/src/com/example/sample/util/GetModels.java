package com.example.sample.util;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.PropertyInfo;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import android.util.Log;

public class GetModels {

	/**     2017年6月28日20:27:44废除  改用  传入json 传回json
	 *  登录验证
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

	 /**  登录验证并返回json
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

    /**  获取  通知list  并返回 json
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
	 * webservices命名空间 
	 */  
	public static final String NAMESPACE = "http://tempuri.org/";  

	/** 
	 * 页面名称 
	 */  
	public static String pageName = "WebService1.asmx";  

	/** 
	 * webservices地址 
	 */  
	public static String webserviceUrl = "http://172.16.33.134:5057/";  

	/** 
	 * 用webservice返回远程数据库数据 
	 *  
	 * @param methodName 
	 *            方法名 
	 * @param propertyInfos 
	 *            参数 
	 * @return 
	 */   
	public static Object getObject(String methodName, PropertyInfo[] propertyInfos) {  
		Log.i("getmodels 类 欢迎到 116行","116");
		Object object = GetWebServiceData(NAMESPACE, webserviceUrl + "/" + pageName, NAMESPACE + methodName, methodName,  
				propertyInfos);  Log.i("getmodels 类 欢迎到 116行","11116");
				Log.i("getmodels 类 欢迎到 119行",String.valueOf(object) );
				return object;  
	}

	/**
	 * 
	 * @param 命名空间
	 * @param iWebserviceURL
	 * @param iSoapAction
	 * @param iMethodName
	 * @param iPropertyInfo
	 * @return
	 */
	private static  Object GetWebServiceData(final String iNameSpace,  
			final String iWebserviceURL,final String iSoapAction,final String iMethodName,  
			final PropertyInfo[] iPropertyInfo)                                { 

		Log.i("getmodels 类 欢迎到 135行","202");
		Object result = null;  
		try {  
			Log.i("getmodels 类 欢迎到 138行","进入try205");
			SoapObject rpc = new SoapObject(iNameSpace, iMethodName);  
			for (int i = 0; i < iPropertyInfo.length; i++) {  
				rpc.addProperty(iPropertyInfo[i]);  
			}  
			Log.i("getmodels 类 欢迎到 143行","进入try210");
			SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(  
					SoapEnvelope.VER12);  
			envelope.bodyOut = rpc;  

			envelope.dotNet = true;  
			envelope.setOutputSoapObject(rpc);  
			Log.i("getmodels 类 欢迎到 150行","进入try217");
			HttpTransportSE ht = new HttpTransportSE(iWebserviceURL, 5000);    
			Log.i("getmodels 类 欢迎到 151行","进入try220");
			ht.debug = true;   
			Log.i("getmodels 类 欢迎到 153行",iSoapAction);
			Log.i("getmodels 类 欢迎到 153行",envelope.enc);
			ht.call(iSoapAction, envelope);   
			Log.i("getmodels 类 欢迎到 153行","进入try224");
			Log.i("getmodels 类 欢迎到 154行","进入try");
			result = envelope.getResponse();  
			Log.i("getmodels 类 欢迎到 146行","进入try227");
		} catch (Exception e) {  
			//            Toast.makeText( getApplicationContext(), "连接服务器失败,请检查网络设置！", Toast.LENGTH_SHORT)  
			//            .show();  
			Log.e("getmodels 152行231", e.getMessage());
		}

		return result;  
	}



}
