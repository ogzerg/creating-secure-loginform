# creating-secure-loginform
Creating Login Form With Extra Security

# What's This?
Most written desktop applications (Windows Forms Applications, Java etc.) can be reverse compiled.
This may lead to the disclosure of codes that should remain confidential within the application. (such as SQL, E-Mail information)

# Okay. What's The Solution?
First of all, I have to say that this is the first solution that came to my mind. In some sources, it is mentioned that the application language (such as C#, Java) is somehow encrypted. Although this may seem like a solution, it is often a costly method and may not be the most accurate solution method.

So the idea came to my mind: Why don't we send the data that needs to be checked through the application to a website and check that website's response?

# The Solution Method: PHP
PHP; It is a programming language that is easy to code and understand.
Therefore, using it in our project will be of great benefit to us.

# Let's Start!
First of all, I will code the project with C#. With similar logic, you can write in other languages such as Java.
First, let's take a look at what I'm talking about.
![alt text](https://github.com/ogzerg/creating-secure-loginform/blob/main/images/winforms%20main.PNG?raw=true)
This is my simple login form on C#.
I'm executing on another class to validate:
![alt text](https://github.com/ogzerg/creating-secure-loginform/blob/main/images/checkUser%20method.PNG?raw=true)
It will return 1 if it finds a value in the database, 0 if not, -1 if it encounters an error.
![alt text](https://github.com/ogzerg/creating-secure-loginform/blob/main/images/login%20screen.gif?raw=true)

As you can see application is running. However, when reverse compiled with various applications, the codes of our application can be read clearly.
![alt text](https://github.com/ogzerg/creating-secure-loginform/blob/main/images/decompiled%20Class.png?raw=true)
As you can see, we were able to see the source codes of the application through another application.

# Coding With PHP
Now we will make our application again with PHP. The logic will be:
We will send the username and password information to our PHP site by POST method and the site will be reflect the result to us in JSON format. Then in our application, that is, in C#, we will enter the user according to the data on this JSON.

# Create loginrequest.php
First, we will run the SQL command over the PHP function.
![alt text](https://github.com/ogzerg/creating-secure-loginform/blob/main/images/php%20class.PNG?raw=true)
This PHP code will check the information entered from the SQL database. Actually the logic is the same as in C#. It will return 1 if it finds a result (that is, if the ordinal number is greater than 0) and 0 else.

Now let's check the incoming POST data.
First, let's check if certain POST values are coming. We use the command "if(isset($_POST["value1"])&&isset($_POST["value2"])&&....)" for this.
![alt text](https://github.com/ogzerg/creating-secure-loginform/blob/main/images/php%20request.PNG?raw=true)

I check the incoming value together with the "loginCheck" parameter, which is unimportant but should come to indicate what operation it is doing. This has no effect on the code. It will only allow us to see what works when we want to look at the code later.
![alt text](https://github.com/ogzerg/creating-secure-loginform/blob/main/images/json%20print.png?raw=true)
# Let's Continue With C#.
Now all we have to do is send the POST parameters to our website with C# and parse the JSON "result" data.
![alt text](https://github.com/ogzerg/creating-secure-loginform/blob/main/images/c%23%20code.png?raw=true)
With this code, we send the data to the site and parse the result.
string url is site address. I used it on my localhost.
When we tested:
![alt text](https://github.com/ogzerg/creating-secure-loginform/blob/main/images/logged%20with%20php.PNG?raw=true)
# Finally:
In this way, we have made our application more secure. In this way, if a person with no good intentions reaches our application, it will see only a website url.
Otherwise, this person can access the database and read the data of all employees and customers and even change and delete this data.

I did it in C#, but it can be implemented with JAVA or another application.
All that is done is to POST the required values and check a result and act on the application accordingly.
You can do not only SQL but many other operations this way. (Like sending an email.)

Everything else is in your imagination!
