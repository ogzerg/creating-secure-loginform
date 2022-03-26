<?php

if (isset($_POST["user"]) && isset($_POST["pass"]) && isset($_POST["loginCheck"])) {
    $check = new request();
    $result = $check->login($_POST["user"], $_POST["pass"]);
    if ($result==1) {
        $js = array('result'=>1);
    }else{
        $js = array('result'=>0);
    }
    echo json_encode($js);
}

class request {

    static $sqlservername = "localhost";
    static $sqlusername = "ogzerg";
    static $sqlpassword = "ogzerg";
    static $sqldatabase = "securelogin";
    static $sqlport = 3306;

    public function login($user, $pass) {
        $conn = new mysqli(request::$sqlservername, request::$sqlusername, request::$sqlpassword, request::$sqldatabase, request::$sqlport);
        $comm = $conn->prepare("SELECT * FROM employees WHERE username=? AND password=?");
        $comm->bind_param('ss', $user, $pass);
        $comm->execute();
        $result = $comm->get_result();
        $row = $result->fetch_all();
        if (count($row) > 0) {
            return 1;
        } else {
            return 0;
        }
    }

}

?>
