import socket

hostname = socket.gethostname()    
IPAddr = socket.gethostbyname(hostname) 

TCP_IP = "0.0.0.0"
#TCP_IP = IPAddr
TCP_PORT = 5002
BUFFER_SIZE = 1024


nameprefix = 'nm!'
players = []




s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.bind((TCP_IP, TCP_PORT))

s.listen(1)
conn, addr = s.accept()

while 1:
    data = conn.recv(BUFFER_SIZE)
    if not data: break
    datastr = data.decode("utf-8")
    if datastr.startswith(nameprefix):
        print(datastr[len(nameprefix):] + " joined")
        players.append(datastr[len(nameprefix):])
    print ("received data:", datastr)
    conn.send(data)  
