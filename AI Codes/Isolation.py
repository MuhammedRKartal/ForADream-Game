import random
import math
import os

# create and return an empty board
def create_board():
    return {3: ' ', 4: ' ', 5: ' ',
            1: ' ', 2: ' '}

# statically coded all possible moves at the beginning of the game
# gets position and returns all posible moves
def all_possible_moves(position):
    all_moves = {
        1: [2, 3, 4],
        2: [1, 3, 4, 5],
        3: [1, 2, 4, 5],
        4: [1, 2, 3, 5],
        5: [2, 4]
    }
    return all_moves[position]

# print the current state of board
def print_board_original(board):
    board_str = "3" + '|' + "4" + '|' + "5"
    board_str += '\n-+-+-\n' + "1" + '|' + "2" + '|' + '/'
    print(board_str)

# print the current state of board
def print_board(board):
    board_str = board[3] + '|' + board[4] + '|' + board[5]
    board_str += '\n-+-+-\n' + board[1] + '|' + board[2] + '|' + '/'
    print(board_str)

# returns the key of the value on the dictionary
def get_position(dictionary, val):
    for item, value in dictionary.items():
        if value == val:
            return item

# takes board, piece and new_pos and makes the movement on the board
def make_move(board, piece, new_pos):
    old_pos = get_position(board, piece)
    if old_pos is not None:
        board[old_pos] = '*'
    board[new_pos] = piece

# takes board and piece and returns possible moving positions as an array
def possible_moves(board, piece):
    position = get_position(board, piece)
    free_positions = []
    if position:
        all_positions = all_possible_moves(position)
        for pos in all_positions:
            if board[pos] == ' ':
                free_positions.append(pos)
    else:
        for i in board.keys():
            if board[i] == ' ':
                free_positions.append(i)
        free_positions.sort(reverse=True)
    return free_positions

# check the board's state and return state
def get_winner(board):
    return 'X' if len(possible_moves(board, 'X')) > 0 else 'O'

# check the board's state and return state
def get_state(board):
    possible_moves_left = len(possible_moves(board, 'X'))
    opponent_possible_moves_left = len(possible_moves(board, 'O'))
    if possible_moves_left == 0 and opponent_possible_moves_left == 0:
        return 0
    elif (possible_moves_left == 0 and opponent_possible_moves_left > 0) or (
            possible_moves_left > 0 and opponent_possible_moves_left == 0):
        return 1
    else:
        return 2

# prompts to user to make a choice and makes the move
def user_turn(board, users_piece):
    choice = int(input("Your turn! Choose a place between 1-5."))
    if choice <= 0 or choice >= 6:
        print("Chose a value between 1-5")
        user_turn(board, users_piece)
    elif choice not in possible_moves(board, users_piece):
        print("Zone is full.")
        user_turn(board, users_piece)
    else:
        make_move(board, users_piece, choice)

# generates a tree by using minimax algorithm and decides the best move
def computer_turn(board, piece):
    print("Computer's turn!")
    best_score, best_move = -math.inf, None
    for move in possible_moves(board, piece):
        dup_board = board.copy()
        make_move(dup_board, piece, move)
        score = minimax(False, piece, 'X' if piece == 'O' else 'O', dup_board)
        if score > best_score:
            best_score = score
            best_move = move
    make_move(board, piece, best_move)

# minimax algorithm
def minimax(is_max_turn, comp_piece, current_piece, board):
    state = get_state(board)
    if state == 0:
        return 0
    elif state == 1:
        return 1 if get_winner(board) == comp_piece else -1

    scores = []
    for move in possible_moves(board, current_piece):
        dup_board = board.copy()
        make_move(dup_board, current_piece, move)
        scores.append(minimax(not is_max_turn, comp_piece, 'X' if current_piece == 'O' else 'O', dup_board))

    return max(scores) if is_max_turn else min(scores)


# generates a random number. if it is 0, user starts first. else, computer starts first.
def game(board, users_piece, computers_piece):
    random_num = random.randint(0, 1)
    if random_num == 0:
        while get_state(board) == 2:
            user_turn(board, users_piece)
            print_board(board)
            if get_state(board) != 2:
                return None
            computer_turn(board, computers_piece)
            print_board(board)
    else:
        while get_state(board) == 2:
            computer_turn(board, computers_piece)
            print_board(board)
            if get_state(board) != 2:
                return None
            user_turn(board, users_piece)
            print_board(board)


# prints the result of the game
def print_result(board, users_piece, computers_piece):
    user_possible_moves_left = len(possible_moves(board, users_piece))
    comp_opponent_possible_moves_left = len(possible_moves(board, computers_piece))
    if user_possible_moves_left == 0 and comp_opponent_possible_moves_left == 0:
        print('Draw!')
    elif user_possible_moves_left == 0 and comp_opponent_possible_moves_left > 0:
        print('Computer won!')
    elif user_possible_moves_left > 0 and comp_opponent_possible_moves_left == 0:
        print('User won!')
    else:
        pass


while True:
    board = create_board()
    print_board_original(board)

    board = create_board()
    users_piece = "X"
    computers_piece = 'O'
    game(board, users_piece, computers_piece)
    print_result(board, users_piece, computers_piece)

    user_response = input("Restart? Press n to exit. Press anything else to restart.")
    if user_response.lower() == "n":
        break
