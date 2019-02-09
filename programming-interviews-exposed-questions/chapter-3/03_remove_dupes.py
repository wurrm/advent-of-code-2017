import sys

given_list = [int(x) for x in sys.argv[1:]]

new_list = []
found = []

# A cool and fast solution from the book: list(set(given_list))
# Provided that they're okay with the list not being in its original order

for x in given_list:
    if x not in found:
        found.append(x)
        new_list.append(x)

print(new_list)
