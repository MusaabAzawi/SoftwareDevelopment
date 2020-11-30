import json
import socket

sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)	
sock.bind(("127.0.0.0", 54000))
sock.listen(5)

print("wait for client response")

with open('jason_controller.json') as f:
	data = json.load(f)


while True:
	clientsocket, address = sock.accept()
	print(f"connection from {address} has been established")
	clientsocket.send(bytes(json.dumps(data), "utf-8"))
	clientsocket.close()
