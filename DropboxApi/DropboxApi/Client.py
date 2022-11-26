import requests
import json
from contextlib import contextmanager
import sys, os

class client():
	def __init__(self):
		self.api_url = "https://localhost:"
		self.data = {}
		self.headers : str={
			'Content-type' : 'application/json',
			'Accept' : 'application/json'
			'XApiKey' : '1234'}

	def exit_client(self, api_exit):
		if api_exit.status_code == 200:
			return
		sys.exit(f'\n{api_exit.json()}, Client wurde beendet\n')

	def login(self):
		api_connect = self.api_url +"/Login"
		print(f'\nLoginsequenz wird gestartet')
		userid = input("Bitte userid eingeben: ")
		email = input("Bitte Email eingeben: ")
		password = input("Bitte Passwort eingeben: ")

		credentials = {
			"Userid" : userid
			"Email" : email
			"Password" : Password
		}

		response = request.post(api_connect, verify = False, header = self.headers, json = bewertung)
		self.exit_client(response)

		print(response.json())
		sys.exit("logged in")

if __name__ == "__main__":
	c = client()
	c.login()