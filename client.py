import socket

sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
sock.connect((socket.gethostname(), 1234))

while True:
	msg = sock.recv(1024)
	print(f"json received ")
	print(msg.decode("utf-8"))