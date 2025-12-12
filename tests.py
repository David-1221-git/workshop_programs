import subprocess

subprocess.run(["python","solution.py"],
stdin=open('imput.txt'),
stdout=open("output.txt","w"),
text=True

)
print("done,check.output.txt")