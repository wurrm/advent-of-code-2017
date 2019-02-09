typedef struct SinglyLinkedNode
{
    int val;
    struct SinglyLinkedNode* next;
} SinglyLinkedNode;

typedef struct DoublyLinkedNode
{
    int val;
    struct DoublyLinkedNode* prev;
    struct DoublyLinkedNode* next;
} DoublyLinkedNode;
