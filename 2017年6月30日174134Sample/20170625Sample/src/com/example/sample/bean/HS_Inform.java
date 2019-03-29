package com.example.sample.bean;

import java.io.Serializable;

public class HS_Inform implements Serializable  {
	public int inform_Id;
	public int inform_Type;
	public int inform_Message_Id;
	public String inform_User_Account;
	public int inform_Message_Time;
	public int inform_Message_Total_Time;
	public String inform_Title;
	public String inform_Content;
	public String inform_Time;
	public String inform_Receive_Time;
	public String remark1;
	public String remark2;
	
	static public boolean primary(String AttributeName){       
		if(AttributeName=="inform_Id")  {
			return false;
		}
		else{
			return true;
		}             
	}
}
