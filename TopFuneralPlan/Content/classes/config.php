<?php 
//session_start();	
	
if( $_SERVER['SERVER_NAME'] == 'localhost'){
	
	//date_default_timezone_set('Asia/Calcutta');
	define("HOST_NAME","localhost");
	define("DB_USERNAME","root");
	define("DB_PASSWORD","");
	define("DB_NAME","admin_websearchmedia");
	// Create connection
	
	$conndb = new mysqli(HOST_NAME, DB_USERNAME, DB_PASSWORD, DB_NAME);
	
	define("HOMEURL","http://localhost/topfunural");	
	define("DIRPATH",realpath(dirname(__FILE__) . DIRECTORY_SEPARATOR . '..' . DIRECTORY_SEPARATOR));
	define("CURRENT_URL",$_SERVER['PHP_SELF']);
	

	 
		
}else{


	//date_default_timezone_set('Asia/Calcutta');
	define("HOST_NAME","37.122.208.128");
	define("DB_USERNAME","admin_ashis");
	define("DB_PASSWORD","lead_software@2017");
	define("DB_NAME","admin_websearchmedia");
	// Create connection
	
	
	define("HOMEURL","https://topfuneralplan.co.uk");	
	define("DIRPATH",realpath(dirname(__FILE__) . DIRECTORY_SEPARATOR . '..' . DIRECTORY_SEPARATOR));
	define("CURRENT_URL",$_SERVER['PHP_SELF']);
	

	
}