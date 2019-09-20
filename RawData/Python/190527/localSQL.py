import pyodbc
# 建立連線字串
server = 'tcp:172.16.77.60\\SQLExpress, 1433'
#server = '.\\SQLEXPRESS' 
database = 'Northwind' 
username = 'test' 
password = '111' 
connectionstring = 'DRIVER={ODBC Driver 17 for SQL Server};SERVER='+server+';DATABASE='+database+';UID='+username+';PWD='+ password
print(connectionstring)
# 開啟連線
conn = pyodbc.connect(connectionstring) 
# 建立Cursor
cursor = conn.cursor()

cursor.execute("SELECT * FROM Products")
row = cursor.fetchone() 
while row: 
    print (row.ProductName) 
    row = cursor.fetchone()