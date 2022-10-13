import pygame


pygame.init()

#화면 크기 설정
screen_width = 480 
screen_height = 640
screen = pygame.display.set_mode((screen_width,screen_height))


#화면 타이틀 설정
pygame.display.set_caption("Nado Game")

#FPS
clock = pygame.time.Clock()

#배경 이미지 불러오기
background = pygame.image.load("C:\\PythonPrac\\pygame_basic\\background.png")

#캐릭터 불러오기
character = pygame.image.load("C:\\PythonPrac\\pygame_basic\\character.png")

character_size = character.get_rect().size # 이미지의 크기를 구해옴
character_width = character_size[0] # 캐릭터의 가로 크기
character_height = character_size[1] # 캐릭터의 세로 크기
character_x_pos = screen_width / 2 - character_width/2 # 화면 가로의 절반 크기 해당하는 위치
character_y_pos = screen_height-character_height # 화면 세로 크기 가장 아래

to_x = 0
to_y = 0

#이동 속도
character_speed = 0.6

#이벤트 루프
running = True 
while running:
    dt = clock.tick(60) # 게임화면의 초당 프레임 수를 설정
    #캐릭터가 1초 동안에 100만큼 이동을 해야됨
    # 10 fps : 1초 동안에 10번 동작 -> 1번에 몇 만큼 이동? 10만큼 
    
    print("fps : "+str(clock.get_fps()))
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False

        if event.type == pygame.KEYDOWN:
            if event.key == pygame.K_LEFT:
                to_x -= character_speed

            if event.key == pygame.K_RIGHT:
                to_x += character_speed
            if event.key == pygame.K_UP:
                to_y -= character_speed
            if event.key == pygame.K_DOWN:
                to_y += character_speed
        if event.type == pygame.KEYUP:
            if event.key == pygame.K_LEFT or event.key == pygame.K_RIGHT:
                to_x= 0                
            elif event.key == pygame.K_UP or event.key == pygame.K_DOWN:
                to_y= 0

    character_x_pos += to_x * dt
    character_y_pos += to_y * dt
    
    if character_x_pos < 0:
        character_x_pos = 0
    elif character_x_pos >screen_width- character_width:
        character_x_pos =  screen_width- character_width
    if character_y_pos <0:
        character_y_pos = 0
    elif character_y_pos > screen_height - character_height:
        character_y_pos = screen_height - character_height
    screen.blit(background,(0,0)) # 배경 그리기

    screen.blit(character,(character_x_pos,character_y_pos))

    pygame.display.update() # 게임화면을 다시 그리기

#pygame 종료
pygame.quit()