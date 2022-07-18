# MRBDatabase2022
Program to interface with the rejection database for QA. This database stores the information on non conforming parts which are rejected. The information pertaining to these parts are input to the database through this program.

# Description
The program interfaces with a local SQLite database on the //svr300-003 network server. It uses a set of commands/queries which are triggered and modified by the user through buttons and fields on a Winform interface. The program also supports generating reports from the information stored on the database which can be exported to Excel/PDF. It also allows users with an admin password to access speciifc functions normal users cannot such as deleting rejects, adding new vendors, etc. The program is coded using .NET C#. 

# File Paths
The released program is stored on the following filepath: "\\svr300-003\smbd\Rejects DB\SQLBackend\"

The file paths referenced within the program are not hardcoded. Instead, they are stored in a ConnectionSettings.settings file (under the properties folder) which the program references. This settings file contains the paths to the main database, backup databases, and templates for the generated reports. 

![image](https://yghe.amzn.ykgw.net/storage/user/572/files/4f4491cd-0e0e-4534-9e43-2b47f452ea97)


# Admin Password

The admin password is also stored in a .settings file under the properties folder, in case it needs to be manually modified/accessed in the future. Obviously, it does not need to be super secure. 

# Potential Problems

There are some potential problems with maintainablitity of the code- specifically the inputbox implementation is a bit messy and does a lot more than simply be an inputbox. 

I'm sure the code could have been more concise in some places, this was the first time I've dealt with a local database in C#, and there was a learning curve.

A local database being hosted on a network server could result in loss of data- the backups should help mitigate this hopefully.

# Program Flow/Explanation for potential future Co-Ops

For future co-ops, or whoever is working on this; the code is commented pretty extensively, so I will just go over a general overview of how the code flows in order to help with understanding the code. 

The user of the program wishes to reject a part which does not meet specification. They open the program, click "New Reject" and select the reject type. If the type is a "Line" reject, the number is auto generated. If they select "Receiving" reject, they have to fill out the reject number theirselves. All information in the database is tied to this reject number. They fill out information, and then click submit. 

The program checks if the required fields are filled out, and then instatiates a new instance of the "Rejects" Class. This class stores all the information input by the user that is going to be insert to the database. 

![image](https://yghe.amzn.ykgw.net/storage/user/572/files/3dc73527-122c-467c-ad2c-e19d6d7d35c1)

After doing so, the method "AddReject" is called, with the Reject class instance as an argument. This method defines the query used to insert the Reject into the database, and then calls the ExecuteWrite method, which is what actually writes it to the database. However, before this can be done the program needs to know what values from the Reject instance apply to the values listed in the query. 

![image](https://yghe.amzn.ykgw.net/storage/user/572/files/37c470b5-eb64-4a4a-85d7-db9907cec694)


For example, a (shortened) insert query would be const string query = "INSERT INTO Rejects (Reject_Number, Part_Number) VALUES (@RejectNum,@PartNum)"

The program needs to figure out which properties of the Rejects instance are assigned to the @RejectNum and @PartNum fields in the query. This is done so through the GenerateArgument method which uses a dictionary to linke the @ fields in the query to the specific values stored in the Rejects class instance.

![image](https://yghe.amzn.ykgw.net/storage/user/572/files/394ecd73-b9a3-40bd-ba97-f382bf32e903)

Now, the ExecuteWrite method is called.

![image](https://yghe.amzn.ykgw.net/storage/user/572/files/78e5dab2-1ee9-4f63-a270-2dd23b8e173c)

The information about the reject the user input before is now safely stored in the database. 

This is a general overview of the program that should get you started. Of course, lots of things are not covered.

The program also supports editing, which is essentially the same process describes above except first using the RejectNumber to read from the database, and then allowing the user to modify the values present. 

The generating report functionality uses the same/similar methods to read from the database based on a query that is built by the user's input and then displays it in a predefined report template. Printing also does this, except using parameters.

Good luck! 
