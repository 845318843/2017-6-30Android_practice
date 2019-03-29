package com.example.sample.bean;

import java.io.Serializable;
 

public  class MessageLess  implements Serializable {
	public int message_Id;
	public String message_Region;
	public String message_Industry;
	public String message_Title;
	public String message_Content;
 
	public String message_State;
	public String message_Creator;
	public String message_Checker;
	public String remark1;
	public String remark2;

	static public boolean primary(String AttributeName){       
		if(AttributeName=="message_Id")  {
			return false;
		}
		else{
			return true;
		}             
	}
}
