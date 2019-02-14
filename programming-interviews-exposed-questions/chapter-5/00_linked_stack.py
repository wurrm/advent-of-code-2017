class LinkedStackNode:
    def __init__(self, val, next):
        self.val = val
        self.next = next

class LinkedStack:
    def __init__(self, *args):
        self.top = None
        for v in args:
            self.push(v)

    def push(self, val):
        node = LinkedStackNode(val, self.top)
        self.top = node

    def pop(self):
        if not self.top:
            return None
        v = self.top.val
        self.top = self.top.next
        return v

    def peek(self):
        return self.top.val

if __name__ == '__main__':

    stack = LinkedStack(4, 6, 'gr', 4, 2, 4.1, 1, 3)

    print(stack.pop())
    print(stack.peek())
    print(stack.pop())

    print()

    v = stack.pop()
    while (v):
        print(v)
        v = stack.pop()
