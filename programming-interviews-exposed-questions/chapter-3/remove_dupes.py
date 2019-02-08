import sys

given_list = [int(x) for x in sys.argv[1:]]

new_list = []
found = []

for x in given_list:
    if x not in found:
        found.append(x)
        new_list.append(x)

print(new_list)
