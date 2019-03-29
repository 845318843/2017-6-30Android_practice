package com.example.sample.util;

import java.sql.Timestamp;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import org.ksoap2.serialization.PropertyInfo;
import org.ksoap2.serialization.SoapObject;

import android.util.Base64;
import android.util.Log;

import com.example.sample.bean.City;
import com.example.sample.bean.MessageEN;
import com.example.sample.bean.MessageLess;
import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

public class MessageUtils {

	/**    2017年6月26日20:27:10 废除   改用gson
	 * 传入 地区和行业
	 * @param region  地区
	 * @param industry  行业
	 * @return   返回消息数组

	public static ArrayList<MessageEN> getMessageENModels(String region, String industry) {
		if(region.contains("全部省份"))  region="";
		if(industry.contains("全部行业")) industry="";
		String methodName = "EntityMessage";
		PropertyInfo[] propertyInfos = new PropertyInfo[2];
		propertyInfos[0] = new PropertyInfo();
		propertyInfos[0].setName("region");
		propertyInfos[0].setValue(region);

		propertyInfos[1] = new PropertyInfo();
		propertyInfos[1].setName("industry");
		propertyInfos[1].setValue(industry);
		Log.e("region",region);
		Log.e("industry",industry);
		SoapObject messageSoapObject = (SoapObject)GetModels.getObject(methodName,propertyInfos);	 
		ArrayList<MessageEN> models = new ArrayList<MessageEN>();
		if (messageSoapObject != null) {
			for (int i = 0; i < messageSoapObject.getPropertyCount(); i++) {
				SoapObject messageENsoapobject = (SoapObject)messageSoapObject.getProperty(i);
				MessageEN message6 = new MessageEN();

				message6._message_Id = Integer.parseInt(messageENsoapobject.getProperty("message_Id").toString());		
				message6._message_Region = String.valueOf( messageENsoapobject.getProperty("message_Region"));
				message6._message_Industry = String.valueOf( messageENsoapobject.getProperty("message_Industry"));
				message6._message_Title = String.valueOf( messageENsoapobject.getProperty("message_Title"));
				message6._message_Content = String.valueOf( messageENsoapobject.getProperty("message_Content"));
				//Log.i("getmodels 类 欢迎到 51行",messageENsoapobject.getProperty("message_Pic").toString() );
				if(messageENsoapobject.hasProperty("message_Pic") )
				{
					message6._message_Pic  = Base64.decode(messageENsoapobject.getProperty("message_Pic").toString(), Base64.DEFAULT);				 
				}Log.i("getmodels 类 欢迎到 55行","debug");
				message6._message_Time = Str2Timestamp(  messageENsoapobject.getProperty("message_Time").toString()  );			
				message6._message_State = String.valueOf( messageENsoapobject.getProperty("message_State"));	
				message6._message_Creator = String.valueOf( messageENsoapobject.getProperty("message_Creator"));
				message6._message_Checker = String.valueOf( messageENsoapobject.getProperty("message_Checker"));
				message6._remark1 = String.valueOf( messageENsoapobject.getProperty("remark1"));
				message6._remark2 = String.valueOf( messageENsoapobject.getProperty("remark2"));	Log.i("getmodels 类 欢迎到 61行","debug");		    
				models.add(message6);	 
			}
		}
		return models;
	}
	 */


	/**        改用gson   不传图片， 图片留到查看某条消息时根据消息id 再传 。
	 * 传入 地区和行业
	 * @param region  地区
	 * @param industry  行业
	 * @return   返回消息数组
	 * **/
	public static List<MessageLess> getMessageENModels(String region, String industry) {
		String methodName = "EntityMessage";
		PropertyInfo[] propertyInfos = new PropertyInfo[2];
		propertyInfos[0] = new PropertyInfo();
		propertyInfos[0].setName("region");
		propertyInfos[0].setValue(region);

		propertyInfos[1] = new PropertyInfo();
		propertyInfos[1].setName("industry");
		propertyInfos[1].setValue(industry);

		Log.d("88行messageutils", "88han");
		//		System.out.println(  getObject(methodName,propertyInfos)  );  Log.d("37行loginSoapObject", "777");
		//	SoapObject loginSoapObject =(SoapObject)getObject(methodName,propertyInfos);
		//  String status =(String) getObject(methodName,propertyInfos);
//		Log.d("92行messageutils", String.valueOf(GetModels.getObject(methodName,propertyInfos)));
		Log.d("93行messageutils", "93不解释");
		//		SoapObject loginsoapobject = (SoapObject)loginSoapObject.getProperty(0);
		String json =String.valueOf(GetModels.getObject(methodName,propertyInfos));  
		return   parseJSONWithGSON( json ); 
	}

	private static List<MessageLess> parseJSONWithGSON(String jsonData) {
		Log.d("103行messageutils", "103不解释");
		Gson gson = new Gson();
//				jsonData = jsonData.replace('"', '\'');	
//				Log.d("106行 替换情况messageutils", String.valueOf(jsonData));
		/*	jsonData = "[{'id': '1','code': 'bj','name': '北京'," +
				"'map': " +"'39.90403, 116.40752599999996'}, " +
						"{'id': '2','code': 'sz'," +
				"'name': '深圳'," +
				"'map': '22.543099, 114.05786799999998'}, " +
				"{'id': '9','code': 'sh'," +
				"'name': '上海','map': '31.230393,121.473704'}," +
				" {'id': '10','code': 'gz'," +
				"'name': '广州','map': '23.129163,113.26443500000005'}]";  

		 List<City> rs= gson.fromJson(jsonData, new TypeToken<List<City>>() {}.getType());
			 Log.d("106行messageutils","114不解释");
			for (City app : rs) {
				Log.d("MainActivity", "id is " + app.id);
				Log.d("MainActivity", "name is " + app.name);
				Log.d("MainActivity", "version is " + app.map);
			}
		 */

		List<MessageLess> MSList = gson.fromJson(jsonData, new TypeToken<List<MessageLess>>() {}.getType());
		Log.d("106行messageutils","127不解释");
		for (MessageLess app : MSList) {
			Log.d("MainActivity", "id is " + app.message_Id);
			Log.d("MainActivity", "name is " + app.message_Title);
			Log.d("MainActivity", "version is " + app.message_Content);
		}
		return MSList;
	}


	/**
	 *  DateTime.tostring（） 转 TimesTamp 
	 * @param str
	 * @return TimesTamp
	 */
	public static Timestamp Str2Timestamp(String str)
	{
		str=str.substring(0, 19);
		str=str.replace('T',' ');		
		Timestamp ans =  Timestamp.valueOf("2010-00-00 00:00:00");
		try {  
			ans = Timestamp.valueOf(str);  
			System.out.println(ans);  
		} 
		catch (Exception e) {  	         
		}  
		return ans;
	}




}
