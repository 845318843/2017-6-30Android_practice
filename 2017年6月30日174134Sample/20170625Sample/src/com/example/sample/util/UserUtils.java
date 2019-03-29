package com.example.sample.util;

import android.util.Log;

import com.example.sample.bean.E_User;
import com.google.gson.Gson;

public class UserUtils {

	 /** 业务层方法  获取登录结果
	 * 
	 * @param e_userin 
	 * @return  
	 */
	public static E_User loginResult(E_User e_userin) {
	  Gson gson = new Gson();
      String jsonin =gson.toJson(e_userin);
      Log.d("92行messageutils", String.valueOf(   jsonin   ));
	  String jsonout = GetModels.getLoginstatus(jsonin);		
	  E_User e_user = gson.fromJson(jsonout,E_User.class );	  
	  return  e_user;
	}
}
