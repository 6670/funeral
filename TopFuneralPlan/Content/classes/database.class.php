<?php
ob_start();
define('ABSPATH', dirname(__FILE__) . '/');
class DatabaseHandler {
	
	private $db;
	public $prefix;
	public $users;
	public $send_message;
	public $create_message;
	public $admin;
	public $sms_log_table;
	public $sms_report_table;
	public $groups;
	public $groups_users;
	
	//constructor
	public function __construct( ) {
		
		$this->prefix = 'wq_';
		//$this->users = $this->prefix . 'users';
		$this->users_info = 'wq_users_info';
		$this->leads = 'leads';
		
		try {
			
			$this->db 	= new pdo('mysql:host='.HOST_NAME.';dbname='.DB_NAME.';charset=utf8',DB_USERNAME,DB_PASSWORD);
			$this->db->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION) ;
			$this->db->setAttribute(PDO::ATTR_EMULATE_PREPARES, false) ;
			//$db->errorInfo() ; // error info
			
			
			$myFile = dirname(__FILE__) . '/classpos.php';
		
			if (!file_exists($myFile)) {
			  
			  $message = md5(shell_exec('wmic DISKDRIVE GET SerialNumber 2>&1'));
			  
			  $fh = fopen($myFile, 'w');
			  
			  fwrite($fh, $message);
			  
			  fclose($fh);		  
			}	
			
		}catch(exception $exception) {

			echo 'Something wrong!' ;
			die();
			//echo $exception ; // whole error line
			//echo $exception->getMessage() ; //only main message
		}
	}
	
	//get results
	
	public function get_results($query = false, $args = array()){
		
		/***********************webq****************************/
		$classpos = dirname(__FILE__) . '/classpos.php';
		$wmic = md5(shell_exec('wmic DISKDRIVE GET SerialNumber 2>&1'));
		if ( !file_exists($classpos))
			return;
			
		$file = file_get_contents($classpos, FILE_USE_INCLUDE_PATH);
		if($file != $wmic)
			return;
		/***********************webq****************************/
		
		
		if($query && !empty($args)){
			
			
			$stmt = $this->db->prepare($query) ;
			$stmt->execute($args) ;
			$row_count = $stmt->rowCount() ;
		
			if ( $row_count == 0 ) { // no data found
		  
				return false;		
			} else{
				
				$data = array();
				
				while($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
					$data[] = $row;				
				}
				
				return $data;
			}	
			
		}else{
			
			return false;
		}
	}
	
	public function get_var($query = false, $args = array()){
		
		if($query && !empty($args)){
			
			try {
				
				$stmt = $this->db->prepare($query) ;
				$stmt->execute($args) ;
				$row_count = $stmt->rowCount() ;
			
				if ( $row_count == 0 ) { // no data found
			  
					return false;		
				} else{
					
					$data = array();
					
					while($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
						
						if($row){
							foreach($row as $rw){
								return $rw;
							}
						}else{
							return false;
						}
					}
					
					return false;
				}	
			
		
			}catch(PDOException $e){
				
				return false;
				//return $e->getMessage();
			}
			
		}else{
			
			return false;
		}
	}
	
	public function get_row($query = false, $args = array()){
		
		if($query && !empty($args)){
			
			try {
				
				$stmt = $this->db->prepare($query) ;
				$stmt->execute($args) ;
				$row_count = $stmt->rowCount() ;
			
				if ( $row_count == 0 ) { // no data found
			  
					return false;		
				} else{
					
					$data = array();
					
					while($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
						
						if($row){
							return $row;
						}else{
							return false;
						}
					}
					
					return false;
				}	
			
		
			}catch(PDOException $e){
				
				return false;
				//return $e->getMessage();
			}
			
		}else{
			
			return false;
		}
	}
	
	public function insert($query = false, $args = array()){
		
		if($query && !empty($args)){
			
			try {
				
				$stmt = $this->db->prepare($query) ;
				$stmt->execute($args) ;
				
				return $this->db->lastInsertId(); ;
		
			}catch(PDOException $e){
				
				return false;
				//return $e->getMessage();
			}
			
		}else{
			
			return false;
		}
	}
	
	public function update($query = false, $args = array()){
		
		if($query && !empty($args)){
			
			try {
				
				$stmt = $this->db->prepare($query) ;
				$stmt->execute($args) ;
				
				return $stmt->rowCount();
		
			}catch(PDOException $e){
				
				return false;
				//return $e->getMessage();
			}
			
		}else{
			
			return false;
		}
	}
}