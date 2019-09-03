import sys

given = [int(x) for x in sys.argv[1:]]

found = {}

# A cool and fast solution from the book: list(set(given_list))
# Provided that they're okay with the list not being in its original order

for x in given:
    found[x] = True

print(list(found.keys()))
