from abc import *
from typing import Optional
import requests

url = 'https://localhost:7037/WebApplicationTestFile'


def authentification():
    userid: Optional[str] = input("UserID: ")
    email: Optional[str] = input("Email: ")
    password: Optional[str] = input("Password: ")


authentification()
myobj = {input("UserID: "): input("Email: "): input("Password: ")}

x = requests.post(url, json=myobj)
print(x.text)
if __name__ == "__main__":
    pass
