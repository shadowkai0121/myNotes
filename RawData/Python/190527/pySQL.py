import pyodbc
# 建立連線字串
server = 'smit09exam.database.windows.net' 
database = 'SMIT09' 
username = 'smit09' 
password = 'Aa20190625' 
connectionstring = 'DRIVER={ODBC Driver 17 for SQL Server};SERVER='+server+';DATABASE='+database+';UID='+username+';PWD='+ password
print(connectionstring)
# 開啟連線
conn = pyodbc.connect(connectionstring) 
# 建立Cursor
cursor = conn.cursor()

cursor.execute("SELECT * FROM Products")
row = cursor.fetchone() 
while row: 
    print (row.ProductName + "\t| " + str(row.UnitPrice)) 
    row = cursor.fetchone()