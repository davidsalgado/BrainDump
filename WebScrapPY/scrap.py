import re
from urllib.request import Request, urlopen

in_file = open('in.txt','r')
out_file = open('out.txt','w+')
err_file = open('err.txt','w+')

count  = 1

url_scrap_all = in_file.readlines()
for url_scrap in url_scrap_all: 
	print("Processing %s %d" % (url_scrap, count))
	count = count+1
	req = Request(url_scrap)
	req.add_header('User-Agent','Chrome')
	try:
		html = urlopen(req).read() 
	except:
		print ("error!")
		err_file.write("%s" % url_scrap)
	else:
		emails = re.findall(b'[\w\.-]+@[\w\.-]+', html) #your regex here ^^
		for email in emails:
		    print (email)
		    out_file.write("%s\r\n" % email)		

print('et voila')
out_file.close()
in_file.close();
err_file.close();
