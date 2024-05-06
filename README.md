# Final-Project-4360
Translate software design artifacts into software code artifacts. 
There are no restrictions on the programming languages, tools, or platforms you choose for implementing the program. Whether it's C#, Java, or even Python can be used for the coding work. However, your implementation should incorporate the following techniques:
Use Three-Tier Architecture for your application:  https://www.ibm.com/cloud/learn/three-tier-architecture
Store your data in a database. You're welcome to use the remote MySQL database I've set up, or choose your preferred database software (e.g., MySQL, SQLite).
Integration with Azure Communication Service: As introduced in the lecture, utilize Azure Communication Service for sending emails. You'll be responsible for defining the content of the email notification.
How to send an email using Azure Communication Service (for C#, Javascript, Java, and Python)
https://learn.microsoft.com/en-us/azure/communication-services/quickstarts/email/send-email?pivots=programming-language-csharp

Attached are SQL scripts to generate mock data for the Residents and StaffLogin tables. Simply copy and run them in your database query to set up the two tables. 
Note: Replace 'YOUR_WT_EMAIL' in the first line of the SQL scripts with your actual WT email. This sets your WT email as the resident's contact. You'll later use this WT email to test the email notification feature.
While you can design your own database tables, ensure that your WT email is still set as the resident’s email. If you need a tool to create mock data, check out https://www.mockaroo.com/

