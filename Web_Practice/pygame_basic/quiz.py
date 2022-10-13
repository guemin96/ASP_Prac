from random import Random, randint, random
import pygame
#####################################################################
#기본 초기화 (반드시 해야 하는 것들)

pygame.init()

#화면 크기 설정
screen_width = 480 
screen_height = 640
screen = pygame.display.set_mode((screen_width,screen_height))


#화면 타이틀 설정
pygame.display.set_caption("게임 이름")

#FPS
clock = pygame.time.Clock()
#####################################################################

# 1. 사용자 게임 초기화 (배경 화면, 게임 이미지, 좌표, 폰트 등)
background = pygame.image.load("C:\\PythonPrac\\pygame_basic\\background_test2.png")

#캐릭터 불러오기
character = pygame.image.load("C:\\PythonPrac\\pygame_basic\\UNIStudent.png")

character_size = character.get_rect().size # 이미지의 크기를 구해옴
character_width = character_size[0] # 캐릭터의 가로 크기
character_height = character_size[1] # 캐릭터의 세로 크기
character_x_pos = screen_width / 2 - character_width/2 # 화면 가로의 절반 크기 해당하는 위치
character_y_pos = screen_height-character_height # 화면 세로 크기 가장 아래

to_x = 0
to_y = 0

#이동 속도
character_speed = 0.6
enemy_speed = 0.5
# enemy 랜덤 위치 값


# 적 enemy 캐릭터
enemy = pygame.image.load("C:\\PythonPrac\\pygame_basic\\assignment.png")
enemy_size = character.get_rect().size # 이미지의 크기를 구해옴
enemy_width = enemy_size[0] # 캐릭터의 가로 크기
enemy_height = enemy_size[1] # 캐릭터의 세로 크기
enemyrandom_x_pos = randint(0,screen_width - enemy_width)
enemy_x_pos = enemyrandom_x_pos # 화면 가로의 절반 크기 해당하는 위치
enemy_y_pos = 0 # 화면 세로 크기 가장 아래




#이벤트 루프
running = True 
while running:
    dt = clock.tick(60) # 게임화면의 초당 프레임 수를 설정

    enemy_y_pos += enemy_speed * dt
    if  enemy_y_pos > screen_height :
        enemy_y_pos = 0
        enemyrandom_x_pos = randint(0,screen_width - enemy_width)
        enemy_x_pos = enemyrandom_x_pos

    # 2. 이벤트 처리(키보드, 마우스 등)
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False

        if event.type == pygame.KEYDOWN:
            if event.key == pygame.K_LEFT:
                to_x -= character_speed

            if event.key == pygame.K_RIGHT:
                to_x += character_speed
        if event.type == pygame.KEYUP:
            if event.key == pygame.K_LEFT or event.key == pygame.K_RIGHT:
                to_x= 0                

    character_x_pos += to_x * dt
    
    if character_x_pos < 0:
        character_x_pos = 0
    elif character_x_pos >screen_width- character_width:
        character_x_pos =  screen_width- character_width

    character_rect = character.get_rect()
    character_rect.left = character_x_pos
    character_rect.top = character_y_pos

    enemy_rect = enemy.get_rect()
    enemy_rect.left = enemy_x_pos
    enemy_rect.top = enemy_y_pos

    if character_rect.colliderect(enemy_rect):
            print("충돌했어요")
            running = False

    # 5. 화면에 그리기
    screen.blit(background,(0,0)) # 배경 그리기

    screen.blit(character,(character_x_pos,character_y_pos))

    screen.blit(enemy,(enemy_x_pos,enemy_y_pos))


    pygame.display.update() # 게임화면을 다시 그리기

#pygame 종료
pygame.quit()