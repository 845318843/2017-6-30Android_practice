package com.example.sample.util;

import java.util.List;

import org.ksoap2.serialization.PropertyInfo;

import android.util.Log;

import com.example.sample.bean.E_User;
import com.example.sample.bean.HS_Inform;
import com.example.sample.bean.MessageLess;
import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

public class HS_InformUtils {

	/**  业务层方法  获取 客服通知
	 * 
	 * @param e_user
	 * @return
	 */
	public static List<HS_Inform> getInformModels(E_User e_userin) {
		Gson gson = new Gson();
		e_userin.user_Create_Time=null;
		String jsonin =gson.toJson(e_userin);
		Log.d("HS_InformU 25h行", String.valueOf(   jsonin   ));
//		String jsonout = GetModels.getLoginstatus(jsonin);	
		String jsonout = GetModels.getHS_Inform(jsonin);	

		return   parseJSONWithGSON( jsonout ); 

	}

	private static List<HS_Inform> parseJSONWithGSON(String jsonData) {
		Log.d("HS_InformUtils", "34行 进入parsejsonwithgson");
		Log.d("HS_InformUtils35",jsonData);
		Gson gson = new Gson();
		List<HS_Inform> MSList = gson.fromJson(jsonData, new TypeToken<List<HS_Inform>>() {}.getType());
		Log.d("HS_InformUtils","完成json转 实体list");
		for (HS_Inform app : MSList) {
			Log.d("MainActivity", "id is " + app.inform_Title);
			Log.d("MainActivity", "name is " + app.inform_Content);
		}
		return MSList;
	}




}
