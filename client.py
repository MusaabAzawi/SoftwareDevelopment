import socket

sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
sock.connect(("127.0.0.1", 54000))

while True:
	msg = sock.recv(1024)
	print(f"json received ")
	print(msg.decode("utf-8"))