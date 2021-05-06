Imports System.IO
Imports WMPLib
Public Class Form1

    Dim bmp As Bitmap
    Dim Bg, Bg1, Img As CImage
    Dim SpriteMap As CImage
    Dim SpriteMask As CImage
    Dim DownFireBall, MegamanGetHit, MegamanAttack, MegamanGetBurned, MegaManFireBall, MegamanWalk, MegamanStand, UpFireBall, FlameStagJump, FlameStagStanceOnTheGround, FlameStagUppercut, FlameStagStanceOnTheWall, FlameStagDeath, FlameStagCharge, FlameStagLanding, FlameStagStand, FlameStagGetHit, FlameStagIntro, FlameStagDownAttack, FlameStagUpAttack, FlameStagDash, FlameStagSmackDown As CArrFrame
    Dim FS As CCharacter
    Dim MM As CMegamen
    Dim ListChar As New List(Of CCharacter)
    Dim x As Boolean
    Dim second As Integer
    Dim second3 As Integer = 99
    Dim second4 As Integer = 99
    Dim second2 As Integer

    Dim MMFire As CMMFireProjectile
    Dim DownFire As CDownFireProjectile
    Dim UpFire As CUpFireProjectile
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'open image for background, assign to bg
        'My.Computer.Audio.Play("C:\Users\ASUS\Downloads\sprite animation v1\bin\Debug\Undertale - Megalovania.mp3")

        'add a media player
        'Dim Player As WindowsMediaPlayer = New WindowsMediaPlayer

        'assign the location of the song to be played
        'Dim SongLocation = "Undertale - Megalovania.mp3" 'any song you want to play
        'play the song
        'Player.URL = SongLocation
        'Player.controls.play()


        Bg = New CImage
        Bg.OpenImage("background.bmp")
        Bg.CopyImg(Img)
        Bg.CopyImg(Bg1)

        SpriteMap = New CImage
        SpriteMap.OpenImage("flamestag4.bmp")
        SpriteMap.CreateMask(SpriteMask)

        'initialize sprites
        FlameStagJump = New CArrFrame

        'FlameStagJump.Insert(37 * 2, 53 * 2, 7 * 2, 27 * 2, 69 * 2, 74 * 2, 1)
        FlameStagJump.Insert(104 * 2, 53 * 2, 77 * 2, 27 * 2, 139 * 2, 74 * 2, 1)
        'FlameStagJump.Insert(149* 2, 43* 2, 125* 2, 13* 2, 176* 2, 71* 2, 1)
        'FlameStagJump.Insert(210* 2, 45* 2, 183* 2, 16* 2, 236* 2, 72* 2, 1)
        'FlameStagJump.Insert(284* 2, 41* 2, 252* 2, 13* 2, 304* 2, 70* 2, 1)
        FlameStagStanceOnTheGround = New CArrFrame

        FlameStagStanceOnTheGround.Insert(37 * 2, 53 * 2, 7 * 2, 27 * 2, 69 * 2, 74 * 2, 10)

        FlameStagStanceOnTheWall = New CArrFrame
        FlameStagStanceOnTheWall.Insert(168 * 2, 44 * 2, 148 * 2, 13 * 2, 186 * 2, 74 * 2, 3)
        FlameStagStanceOnTheWall.Insert(220 * 2, 44 * 2, 195 * 2, 13 * 2, 246 * 2, 71 * 2, 3)
        FlameStagStanceOnTheWall.Insert(279 * 2, 44 * 2, 253 * 2, 16 * 2, 306 * 2, 72 * 2, 3)
        FlameStagStanceOnTheWall.Insert(353 * 2, 41 * 2, 322 * 2, 13 * 2, 37 * 24, 70 * 2, 3)

        FlameStagLanding = New CArrFrame
        FlameStagLanding.Insert(30 * 2, 125 * 2, 13 * 2, 92 * 2, 51 * 2, 158 * 2, 1)
        FlameStagLanding.Insert(73 * 2, 125 * 2, 56 * 2, 100 * 2, 93 * 2, 158 * 2, 1)
        FlameStagLanding.Insert(124 * 2, 139 * 2, 98 * 2, 115 * 2, 147 * 2, 157 * 2, 1)
        FlameStagLanding.Insert(178 * 2, 139 * 2, 152 * 2, 115 * 2, 199 * 2, 156 * 2, 1)

        FlameStagIntro = New CArrFrame
        FlameStagIntro.Insert(33 * 2, 203 * 2, 8 * 2, 176 * 2, 58 * 2, 225 * 2, 2)
        FlameStagIntro.Insert(95 * 2, 203 * 2, 71 * 2, 176 * 2, 120 * 2, 225 * 2, 2)
        FlameStagIntro.Insert(157 * 2, 203 * 2, 131 * 2, 176 * 2, 187 * 2, 225 * 2, 2)
        FlameStagIntro.Insert(214 * 2, 203 * 2, 192 * 2, 176 * 2, 239 * 2, 225 * 2, 2)
        FlameStagIntro.Insert(274 * 2, 203 * 2, 245 * 2, 183 * 2, 300 * 2, 225 * 2, 2)
        FlameStagIntro.Insert(343 * 2, 203 * 2, 306 * 2, 183 * 2, 370 * 2, 225 * 2, 2)
        FlameStagIntro.Insert(403 * 2, 203 * 2, 374 * 2, 178 * 2, 428 * 2, 225 * 2, 2)
        FlameStagIntro.Insert(460 * 2, 203 * 2, 431 * 2, 179 * 2, 484 * 2, 225 * 2, 2)
        FlameStagIntro.Insert(516 * 2, 203 * 2, 492 * 2, 171 * 2, 541 * 2, 225 * 2, 2)
        FlameStagIntro.Insert(571 * 2, 203 * 2, 549 * 2, 167 * 2, 597 * 2, 225 * 2, 2)
        FlameStagIntro.Insert(622 * 2, 203 * 2, 606 * 2, 158 * 2, 645 * 2, 225 * 2, 2)


        FlameStagDownAttack = New CArrFrame
        FlameStagDownAttack.Insert(32 * 2, 267 * 2, 9 * 2, 238 * 2, 56 * 2, 288 * 2, 2)
        FlameStagDownAttack.Insert(92 * 2, 267 * 2, 69 * 2, 238 * 2, 117 * 2, 289 * 2, 2)
        FlameStagDownAttack.Insert(151 * 2, 267 * 2, 126 * 2, 238 * 2, 180 * 2, 289 * 2, 1)
        FlameStagDownAttack.Insert(213 * 2, 267 * 2, 188 * 2, 240 * 2, 243 * 2, 289 * 2, 1)
        FlameStagDownAttack.Insert(277 * 2, 267 * 2, 255 * 2, 237 * 2, 302 * 2, 289 * 2, 1)
        FlameStagDownAttack.Insert(346 * 2, 267 * 2, 316 * 2, 248 * 2, 376 * 2, 289 * 2, 1)
        FlameStagDownAttack.Insert(415 * 2, 267 * 2, 381 * 2, 248 * 2, 446 * 2, 289 * 2, 1)
        FlameStagDownAttack.Insert(493 * 2, 267 * 2, 455 * 2, 248 * 2, 523 * 2, 289 * 2, 1)
        FlameStagDownAttack.Insert(577 * 2, 267 * 2, 529 * 2, 248 * 2, 607 * 2, 289 * 2, 1)
        FlameStagDownAttack.Insert(672 * 2, 267 * 2, 616 * 2, 248 * 2, 703 * 2, 289 * 2, 1)

        FlameStagUpAttack = New CArrFrame
        FlameStagUpAttack.Insert(41 * 2, 330 * 2, 12 * 2, 308 * 2, 66 * 2, 355 * 2, 1)
        FlameStagUpAttack.Insert(107 * 2, 330 * 2, 77 * 2, 309 * 2, 129 * 2, 355 * 2, 1)
        FlameStagUpAttack.Insert(174 * 2, 330 * 2, 143 * 2, 309 * 2, 196 * 2, 355 * 2, 1)
        FlameStagUpAttack.Insert(242 * 2, 330 * 2, 211 * 2, 303 * 2, 264 * 2, 355 * 2, 1)
        FlameStagUpAttack.Insert(315 * 2, 330 * 2, 279 * 2, 296 * 2, 341 * 2, 355 * 2, 1)
        FlameStagUpAttack.Insert(374 * 2, 330 * 2, 350 * 2, 296 * 2, 399 * 2, 355 * 2, 1)

        FlameStagSmackDown = New CArrFrame
        FlameStagSmackDown.Insert(227 * 2, 505 * 2, 212 * 2, 472 * 2, 244 * 2, 545 * 2, 1)

        FlameStagDash = New CArrFrame
        FlameStagDash.Insert(48 * 2, 398 * 2, 10 * 2, 362 * 2, 80 * 2, 428 * 2, 1)
        FlameStagDash.Insert(134 * 2, 398 * 2, 96 * 2, 362 * 2, 165 * 2, 428 * 2, 1)
        FlameStagDash.Insert(218 * 2, 398 * 2, 177 * 2, 362 * 2, 250 * 2, 428 * 2, 1)
        FlameStagDash.Insert(308 * 2, 398 * 2, 258 * 2, 362 * 2, 341 * 2, 428 * 2, 1)
        FlameStagDash.Insert(405 * 2, 398 * 2, 347 * 2, 362 * 2, 437 * 2, 428 * 2, 1)
        FlameStagDash.Insert(508 * 2, 398 * 2, 443 * 2, 362 * 2, 540 * 2, 428 * 2, 1)
        FlameStagDash.Insert(620 * 2, 398 * 2, 546 * 2, 360 * 2, 652 * 2, 428 * 2, 1)
        FlameStagDash.Insert(739 * 2, 398 * 2, 657 * 2, 360 * 2, 770 * 2, 428 * 2, 1)
        FlameStagDash.Insert(869 * 2, 398 * 2, 777 * 2, 360 * 2, 898 * 2, 428 * 2, 1)
        FlameStagDash.Insert(1003 * 2, 398 * 2, 905 * 2, 360 * 2, 1034 * 2, 428 * 2, 1)
        FlameStagDash.Insert(1225 * 2, 398 * 2, 1041 * 2, 360 * 2, 1255 * 2, 428 * 2, 1)

        FlameStagUppercut = New CArrFrame
        FlameStagUppercut.Insert(38 * 2, 510 * 2, 15 * 2, 479 * 2, 52 * 2, 544 * 2, 3)
        FlameStagUppercut.Insert(72 * 2, 510 * 2, 58 * 2, 474 * 2, 87 * 2, 545 * 2, 3)
        FlameStagUppercut.Insert(108 * 2, 510 * 2, 94 * 2, 471 * 2, 123 * 2, 545 * 2, 3)
        FlameStagUppercut.Insert(163 * 2, 492 * 2, 132 * 2, 451 * 2, 193 * 2, 546 * 2, 25)

        FlameStagCharge = New CArrFrame
        FlameStagCharge.Insert(827 * 2, 44 * 2, 801 * 2, 15 * 2, 852 * 2, 67 * 2, 5)
        FlameStagCharge.Insert(880 * 2, 44 * 2, 857 * 2, 16 * 2, 906 * 2, 67 * 2, 5)

        FlameStagDeath = New CArrFrame
        FlameStagDeath.Insert(1656, 250, 1602, 180, 1688, 300, 1)
        FlameStagDeath.Insert(1666, 250, 1710, 192, 1802, 296, 1)

        FlameStagGetHit = New CArrFrame
        FlameStagGetHit.Insert(830 * 2, 201 * 2, 803 * 2, 171 * 2, 856 * 2, 224 * 2, 2)

        FlameStagStand = New CArrFrame
        FlameStagStand.Insert(66, 406, 16, 352, 116, 450, 1)
        ' FlameStagStand.Insert(827 * 2, 44 * 2, 801 * 2, 15 * 2, 852 * 2, 67 * 2, 1)

        DownFireBall = New CArrFrame
        DownFireBall.Insert(604 * 2, 483 * 2, 593 * 2, 473 * 2, 618 * 2, 493 * 2, 1)
        DownFireBall.Insert(633 * 2, 483 * 2, 623 * 2, 473 * 2, 650 * 2, 491 * 2, 1)
        DownFireBall.Insert(667 * 2, 483 * 2, 655 * 2, 472 * 2, 681 * 2, 493 * 2, 1)
        DownFireBall.Insert(696 * 2, 483 * 2, 686 * 2, 471 * 2, 711 * 2, 490 * 2, 1)

        UpFireBall = New CArrFrame
        UpFireBall.Insert(724 * 2, 527 * 2, 717 * 2, 517 * 2, 732 * 2, 545 * 2, 1)
        UpFireBall.Insert(743 * 2, 527 * 2, 736 * 2, 517 * 2, 750 * 2, 545 * 2, 1)
        UpFireBall.Insert(762 * 2, 527 * 2, 755 * 2, 517 * 2, 769 * 2, 545 * 2, 1)
        UpFireBall.Insert(781 * 2, 527 * 2, 774 * 2, 517 * 2, 790 * 2, 545 * 2, 1)

        MegamanStand = New CArrFrame
        MegamanStand.Insert(43 * 2, 600 * 2, 19 * 2, 574 * 2, 61 * 2, 617 * 2, 1)
        MegamanStand.Insert(92 * 2, 600 * 2, 68 * 2, 574 * 2, 110 * 2, 617 * 2, 1)
        MegamanStand.Insert(141 * 2, 600 * 2, 117 * 2, 574 * 2, 159 * 2, 617 * 2, 1)
        MegamanStand.Insert(187 * 2, 600 * 2, 165 * 2, 574 * 2, 204 * 2, 617 * 2, 1)
        MegamanStand.Insert(228 * 2, 600 * 2, 208 * 2, 574 * 2, 245 * 2, 618 * 2, 1)

        MegamanWalk = New CArrFrame
        MegamanWalk.Insert(30 * 2, 654 * 2, 15 * 2, 628 * 2, 46 * 2, 669 * 2, 1)
        MegamanWalk.Insert(70 * 2, 654 * 2, 50 * 2, 628 * 2, 86 * 2, 669 * 2, 1)
        MegamanWalk.Insert(117 * 2, 654 * 2, 93 * 2, 628 * 2, 140 * 2, 669 * 2, 1)
        MegamanWalk.Insert(167 * 2, 654 * 2, 146 * 2, 629 * 2, 183 * 2, 668 * 2, 1)
        MegamanWalk.Insert(207 * 2, 654 * 2, 192 * 2, 629 * 2, 222 * 2, 669 * 2, 1)
        MegamanWalk.Insert(241 * 2, 654 * 2, 229 * 2, 631 * 2, 258 * 2, 669 * 2, 1)
        MegamanWalk.Insert(284 * 2, 654 * 2, 269 * 2, 630 * 2, 298 * 2, 669 * 2, 1)
        MegamanWalk.Insert(330 * 2, 654 * 2, 310 * 2, 631 * 2, 351 * 2, 669 * 2, 1)
        MegamanWalk.Insert(376 * 2, 654 * 2, 360 * 2, 629 * 2, 393 * 2, 669 * 2, 1)
        MegamanWalk.Insert(416 * 2, 654 * 2, 403 * 2, 631 * 2, 432 * 2, 669 * 2, 1)

        MegamanAttack = New CArrFrame
        MegamanAttack.Insert(38 * 2, 711 * 2, 14 * 2, 685 * 2, 53 * 2, 727 * 2, 1)
        MegamanAttack.Insert(81 * 2, 711 * 2, 57 * 2, 685 * 2, 104 * 2, 727 * 2, 1)
        MegamanAttack.Insert(132 * 2, 711 * 2, 109 * 2, 685 * 2, 158 * 2, 727 * 2, 1)
        MegamanAttack.Insert(185 * 2, 711 * 2, 162 * 2, 685 * 2, 208 * 2, 726 * 2, 1)

        MegaManFireBall = New CArrFrame
        MegaManFireBall.Insert(225 * 2, 705 * 2, 220 * 2, 700 * 2, 231 * 2, 709 * 2, 1)

        MegamanGetHit = New CArrFrame
        MegamanGetHit.Insert(35 * 2, 776 * 2, 18 * 2, 748 * 2, 55 * 2, 793 * 2, 1)
        MegamanGetHit.Insert(80 * 2, 776 * 2, 61 * 2, 748 * 2, 104 * 2, 792 * 2, 1)
        MegamanGetHit.Insert(133 * 2, 776 * 2, 111 * 2, 748 * 2, 154 * 2, 792 * 2, 1)
        MegamanGetHit.Insert(183 * 2, 776 * 2, 162 * 2, 749 * 2, 205 * 2, 788 * 2, 1)


        MegamanGetBurned = New CArrFrame
        MegamanGetBurned.Insert(178 * 2, 826 * 2, 153 * 2, 801 * 2, 192 * 2, 853 * 2, 1)
        MegamanGetBurned.Insert(225 * 2, 826 * 2, 200 * 2, 801 * 2, 240 * 2, 853 * 2, 1)
        MegamanGetBurned.Insert(271 * 2, 826 * 2, 245 * 2, 800 * 2, 289 * 2, 855 * 2, 1)
        MegamanGetBurned.Insert(327 * 2, 826 * 2, 299 * 2, 797 * 2, 344 * 2, 855 * 2, 1)

        MM = New CMegamen
        ReDim MM.ArrSprites(13)
        MM.ArrSprites(0) = MegamanStand
        MM.ArrSprites(1) = MegamanWalk
        MM.ArrSprites(2) = MegamanAttack
        MM.ArrSprites(3) = MegamanGetHit
        MM.ArrSprites(4) = MegamanWalk
        MM.ArrSprites(5) = MegamanGetBurned
        MM.ArrSprites(6) = MegamanStand
        MM.ArrSprites(7) = MegamanStand
        MM.ArrSprites(8) = MegamanStand
        MM.ArrSprites(9) = MegamanStand
        MM.ArrSprites(10) = MegamanStand
        MM.ArrSprites(11) = MegamanStand
        MM.ArrSprites(12) = MegamanStand
        MM.ArrSprites(13) = MegamanStand

        FS = New CCharacter
        ReDim FS.ArrSprites(13)

        FS.ArrSprites(0) = FlameStagIntro
        FS.ArrSprites(1) = FlameStagUppercut
        FS.ArrSprites(2) = FlameStagDeath
        FS.ArrSprites(3) = FlameStagCharge
        FS.ArrSprites(4) = FlameStagLanding
        FS.ArrSprites(5) = FlameStagGetHit
        FS.ArrSprites(6) = FlameStagStand
        FS.ArrSprites(7) = FlameStagJump
        FS.ArrSprites(8) = FlameStagDownAttack
        FS.ArrSprites(9) = FlameStagUpAttack
        FS.ArrSprites(10) = FlameStagDash
        FS.ArrSprites(11) = FlameStagSmackDown
        FS.ArrSprites(12) = FlameStagStanceOnTheGround
        FS.ArrSprites(13) = FlameStagStanceOnTheWall

        FS.PosX = 100
        FS.PosY = 370
        FS.Vx = 55
        FS.Vy = 20
        FS.godown = True
        FS.dointro = True
        FS.State(StateSplitMushroom.JumpDown, 7)
        FS.FDir = FaceDir.Right

        bmp = New Bitmap(Img.Width, Img.Height)
        ListChar.Add(FS)
        MM.PosX = 150
        MM.PosY = 720
        MM.Vx = 0
        MM.Vy = 0
        MM.State(StateMegaMan.MMStand, 0)
        MM.FDir = FaceDir.Left
        ListChar.Add(MM)
        'bmp2 = New Bitmap(Img.Width, Img.Height)
        MMFire = New CMMFireProjectile

        ReDim MMFire.ArrSprites(0)
        MMFire.CurrState = StateMMFireballs.CreateMM
        MMFire.ArrSprites(0) = MegaManFireBall
        ListChar.Add(MMFire)

        DownFire = New CDownFireProjectile
        ReDim DownFire.ArrSprites(1)
        DownFire.ArrSprites(0) = DownFireBall
        DownFire.ArrSprites(1) = DownFireBall

        UpFire = New CUpFireProjectile
        ReDim UpFire.ArrSprites(1)
        UpFire.ArrSprites(0) = UpFireBall
        UpFire.ArrSprites(1) = UpFireBall

        ListChar.Add(DownFire)
        ListChar.Add(UpFire)
        DisplayImg()
        'DisplayImgMegaMan()
        ResizeImg()
        'PlayLoopingBackgroundSoundResource()
        Timer1.Enabled = True

    End Sub
    Sub PlayLoopingBackgroundSoundResource()
        My.Computer.Audio.Play(My.Resources.FlameStag,
          AudioPlayMode.BackgroundLoop)
    End Sub

    Public Function CollisionDetection(frame1 As CElmtFrame, frame2 As CElmtFrame, object1 As CCharacter, object2 As CCharacter)
        Dim L1, L2, R1, R2, T1, T2, B1, B2 As Integer

        L1 = frame1.Left - frame1.CtrPoint.x + object1.PosX - 30
        R1 = frame1.Right - frame1.CtrPoint.x + object1.PosX - 30
        T1 = frame1.Top - frame1.CtrPoint.y + object1.PosY - 30
        B1 = frame1.Bottom - frame1.CtrPoint.y + object1.PosY - 30

        L2 = frame2.Left - frame2.CtrPoint.x + object2.PosX - 30
        R2 = frame2.Right - frame2.CtrPoint.x + object2.PosX - 30
        T2 = frame2.Top - frame2.CtrPoint.y + object2.PosY - 30
        B2 = frame2.Bottom - frame2.CtrPoint.y + object2.PosY - 30

        If L2 < R1 And L1 < R2 And T1 < B2 And T2 < B1 Then
            Return True
        Else
            Return False
        End If

    End Function

    Sub PutSprite()
        Dim cc As CCharacter

        Dim i, j As Integer
        'set background
        For i = 0 To Img.Width - 1
            For j = 0 To Img.Height - 1
                Img.Elmt(i, j) = Bg1.Elmt(i, j)
            Next
        Next

        Dim scrX, scrY As Integer
        Dim half As Integer = Img.Height \ 2
        scrX = FS.PosX
        If FS.PosY < half Then
            For i = 0 To Img.Width - 1
                For j = 0 To Img.Height - 1
                    Img.Elmt(i, j) = Bg.Elmt(i, j)
                Next
            Next
            scrY = FS.PosY
        ElseIf FS.PosY > Bg.Height - half Then
            For i = 0 To Img.Width - 1
                For j = 0 To Img.Height - 1
                    Img.Elmt(i, j) = Bg.Elmt(i, Bg.Height - Img.Height + j)
                Next
            Next
            scrY = FS.PosY - Bg.Height + Img.Height
        Else
            For i = 0 To Img.Width - 1
                For j = 0 To Img.Height - 1
                    Img.Elmt(i, j) = Bg.Elmt(i, FS.PosY - half + j)
                Next
            Next
            scrY = half
        End If
        For Each cc In ListChar

            Dim EF As CElmtFrame = cc.ArrSprites(cc.IdxArrSprites).Elmt(cc.FrameIdx)

            Dim spritewidth = EF.Right - EF.Left
            Dim spriteheight = EF.Bottom - EF.Top
            Dim imgx, imgy As Integer




            If cc.FDir = FaceDir.Left Then
                Dim spriteleft As Integer = cc.PosX - EF.CtrPoint.x + EF.Left
                Dim spritetop As Integer = cc.PosY - FS.PosY + scrY - EF.CtrPoint.y + EF.Top
                'set mask

                For i = 0 To spritewidth
                    For j = 0 To spriteheight
                        imgx = spriteleft + i
                        imgy = spritetop + j
                        If spriteleft + i >= 0 And spriteleft + i <= Img.Width - 1 And spritetop + j >= 0 And spritetop + j <= Img.Height - 1 Then
                            Img.Elmt(spriteleft + i, spritetop + j) = OpAnd(Img.Elmt(spriteleft + i, spritetop + j), SpriteMask.Elmt(EF.Left + i, EF.Top + j))
                        End If

                    Next
                Next

                'set sprite
                For i = 0 To spritewidth
                    For j = 0 To spriteheight
                        If spriteleft + i >= 0 And spriteleft + i <= Img.Width - 1 And spritetop + j >= 0 And spritetop + j <= Img.Height - 1 Then
                            Img.Elmt(spriteleft + i, spritetop + j) = OpOr(Img.Elmt(spriteleft + i, spritetop + j), SpriteMap.Elmt(EF.Left + i, EF.Top + j))
                        End If

                    Next
                Next
            Else 'facing right
                Dim spriteleft = cc.PosX + EF.CtrPoint.x - EF.Right
                Dim spritetop = cc.PosY - FS.PosY + scrY - EF.CtrPoint.y + EF.Top
                'set mask
                For i = 0 To spritewidth
                    For j = 0 To spriteheight
                        If spriteleft + i >= 0 And spriteleft + i <= Img.Width - 1 And spritetop + j >= 0 And spritetop + j <= Img.Height - 1 Then
                            Img.Elmt(spriteleft + i, spritetop + j) = OpAnd(Img.Elmt(spriteleft + i, spritetop + j), SpriteMask.Elmt(EF.Right - i, EF.Top + j))
                        End If

                    Next
                Next

                'set sprite
                For i = 0 To spritewidth
                    For j = 0 To spriteheight
                        If spriteleft + i >= 0 And spriteleft + i < Img.Width - 1 And spritetop + j >= 0 And spritetop + j <= Img.Height - 1 Then
                            Img.Elmt(spriteleft + i, spritetop + j) = OpOr(Img.Elmt(spriteleft + i, spritetop + j), SpriteMap.Elmt(EF.Right - i, EF.Top + j))
                        End If

                    Next
                Next

            End If
        Next


    End Sub


    Sub DisplayImg()
        'display bg and sprite on picturebox
        Dim i, j As Integer
        PutSprite()

        For i = 0 To Img.Width - 1
            For j = 0 To Img.Height - 1
                bmp.SetPixel(i, j, Img.Elmt(i, j))
            Next
        Next
        PictureBox1.Refresh()
        'PictureBox1.Refresh()

        PictureBox1.Image = bmp
        PictureBox1.Width = bmp.Width
        PictureBox1.Height = bmp.Height
        PictureBox1.Top = 0
        PictureBox1.Left = 0
        'Me.Width = PictureBox1.Width + 30
        'Me.Height = PictureBox1.Height + 100
    End Sub
    Sub ResizeImg()
        Dim w, h As Integer
        w = PictureBox1.Width
        h = PictureBox1.Height
        Me.ClientSize = New Size(w, h)

    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        'detect up arrow key
        If keyData = Keys.Up And FS.CurrState = StateSplitMushroom.Stand Then
            If FS.FDir = FaceDir.Left Then
                FS.Vx = -90
                FS.Vy = -30
                FS.State(StateSplitMushroom.JumpStance, 12)
            ElseIf FS.FDir = FaceDir.Right Then
                FS.Vx = 90
                FS.Vy = -30
                FS.State(StateSplitMushroom.JumpStance, 12)

            End If
        End If
        'detect down arrow key
        If keyData = Keys.Down Then
            If FS.PosY = 710 Then
                FS.State(StateSplitMushroom.Stand, 6)
            End If
            If FS.CurrState = StateSplitMushroom.ChangeStance Then
                FS.godown = True
                If FS.FDir = FaceDir.Left Then
                    FS.Vx = -40
                    FS.Vy = 8
                    '  FS.State(StateSplitMushroom.JumpDown, 7)
                ElseIf FS.FDir = FaceDir.Right Then
                    FS.Vx = 40
                    FS.Vy = 8
                    '  FS.State(StateSplitMushroom.JumpDown, 7)

                End If
            End If
        End If

        'detect left arrow key
        If keyData = Keys.Left And FS.CurrState = StateSplitMushroom.Stand Then 'dash left Then
            If FS.PosY >= 710 Then
                FS.PosY = 710
                FS.FDir = FaceDir.Left
                FS.Vx = -50
                'FS.doSmackDown = True
                FS.State(StateSplitMushroom.Charge, 3)

            End If
        End If

        'detect right arrow key
        If keyData = Keys.Right And FS.CurrState = StateSplitMushroom.Stand Then ' dash right
            If FS.PosY >= 710 Then
                FS.PosY = 710
                FS.FDir = FaceDir.Right
                'FS.doSmackDown = True
                FS.State(StateSplitMushroom.Charge, 3)

                FS.Vx = 50
            End If
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim input As String
        input = e.KeyCode
        If FS.CurrState = StateSplitMushroom.Stand Then
            Select Case input
                Case 32 'spacebar
                    If FS.PosY >= 710 Then
                        FS.PosY = 710
                        FS.State(StateSplitMushroom.DownAttack, 8)

                    End If
                Case Keys.Z
                    If FS.PosY >= 710 Then
                        FS.doUppercut = True
                        If FS.FDir = FaceDir.Left Then
                            FS.Vx = -40
                            FS.Vy = -8
                            FS.State(StateSplitMushroom.JumpStance, 12)
                        ElseIf FS.FDir = FaceDir.Right Then
                            FS.Vx = 40
                            FS.Vy = -8
                            FS.State(StateSplitMushroom.JumpStance, 12)
                        End If
                    End If



            End Select
        End If
        If MM.CurrState = StateMegaMan.MMStand Then

            Select Case input
                Case Keys.D
                    If MM.CurrState = StateMegaMan.MMStand Then
                        MM.FDir = FaceDir.Left
                        MM.State(StateMegaMan.MMWalk, 1)
                        MM.Vx = 25
                        MM.PosX = MM.PosX + MM.Vx


                        MM.Vx = 0
                        second = 0
                    End If
                Case Keys.A
                    If MM.CurrState = StateMegaMan.MMStand Then
                        MM.FDir = FaceDir.Right
                        MM.State(StateMegaMan.MMWalk, 1)
                        MM.Vx = -25
                        MM.PosX = MM.PosX + MM.Vx

                        MM.Vx = 0
                        second = 0
                    End If
                Case Keys.S
                    MM.State(StateMegaMan.MMAttack, 2)
                    second = 0
            End Select
        End If

    End Sub
    'Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
    '    If e.KeyChar = ChrW(Keys.D) Or e.KeyChar = Char.ToLower(ChrW(Keys.D)) Then

    '        MM.FDir = FaceDir.Left
    '        MM.State(StateMegaMan.MMWalk, 1)
    '        MM.Vx = 25

    '        MM.PosX = MM.PosX + MM.Vx

    '        MM.Vx = 0
    '        second = 0


    '    End If
    '    If e.KeyChar = ChrW(Keys.A) Or e.KeyChar = Char.ToLower(ChrW(Keys.A)) Then

    '        MM.FDir = FaceDir.Right
    '        MM.State(StateMegaMan.MMWalk, 1)
    '        MM.Vx = -25
    '        MM.PosX = MM.PosX + MM.Vx
    '        MM.Vx = 0
    '        second = 0

    '    End If

    '    If e.KeyChar = ChrW(Keys.S) Or e.KeyChar = Char.ToLower(ChrW(Keys.S)) Then

    '        MM.State(StateMegaMan.MMAttack, 2)
    '        second = 0

    '    End If

    'End Sub
    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        ' by making Generator static, we preserve the same instance '
        ' (i.e., do not create new instances with the same seed over and over) '
        ' between calls '
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function

    Sub MegaManRespawn(frame1 As CElmtFrame, object1 As CCharacter)
        Dim L1, R1 As Integer
        L1 = frame1.Left - frame1.CtrPoint.x + object1.PosX
        R1 = frame1.Right - frame1.CtrPoint.x + object1.PosX

        MM = New CMegamen
        ReDim MM.ArrSprites(13)
        MM.ArrSprites(0) = MegamanStand
        MM.ArrSprites(1) = MegamanWalk
        MM.ArrSprites(2) = MegamanAttack
        MM.ArrSprites(3) = MegamanGetHit
        MM.ArrSprites(4) = MegamanWalk
        MM.ArrSprites(5) = MegamanGetBurned
        MM.ArrSprites(6) = MegamanStand
        MM.ArrSprites(7) = MegamanStand
        MM.ArrSprites(8) = MegamanStand
        MM.ArrSprites(9) = MegamanStand
        MM.ArrSprites(10) = MegamanStand
        MM.ArrSprites(11) = MegamanStand
        MM.ArrSprites(12) = MegamanStand
        MM.ArrSprites(13) = MegamanStand
        ListChar.Add(MM)

        Dim randoms(1000) As Integer
        For i As Integer = 0 To randoms.Length - 1
            randoms(i) = GetRandom(100, 500)
            If randoms(i) < L1 - 50 Or randoms(i) > R1 + 50 Then
                MM.PosX = randoms(i)
                MM.Destroy = False
                MM.PosY = 720
                MM.State(StateMegaMan.MMStand, 0)
                MM.FDir = FaceDir.Left
                Exit For
            End If
        Next

    End Sub
    Sub CreateMMFireball()

        MMFire = New CMMFireProjectile

        ReDim MMFire.ArrSprites(1)
        MMFire.CurrState = StateMMFireballs.CreateMM

        MMFire.ArrSprites(0) = MegaManFireBall

        ListChar.Add(MMFire)

        If MM.FDir = FaceDir.Right Then
            MMFire.PosX = MM.PosX - 80
            MMFire.FDir = FaceDir.Left
        Else
            MMFire.PosX = MM.PosX + 80
            MMFire.FDir = FaceDir.Right
        End If
        MMFire.PosY = MM.PosY - 9
        MMFire.Vy = 0

        If MM.FDir = FaceDir.Right Then
            MMFire.Vx = -40
        Else
            MMFire.Vx = 40
        End If


    End Sub

    Sub CreateDownFireball()
        DownFire = New CDownFireProjectile
        ReDim DownFire.ArrSprites(0)
        DownFire.ArrSprites(0) = DownFireBall




        ListChar.Add(DownFire)


        If FS.FDir = FaceDir.Left Then
            DownFire.PosX = FS.PosX - 80
            DownFire.FDir = FaceDir.Left


        Else
            DownFire.PosX = FS.PosX + 80
            DownFire.FDir = FaceDir.Right


        End If



        DownFire.PosY = FS.PosY - 3
        'Fire.Vx = 0
        DownFire.Vy = 0



        If FS.FDir = FaceDir.Left Then
            DownFire.Vx = -40

        Else
            DownFire.Vx = 40

        End If


        DownFire.CurrState = DownStateFireballs.Create


    End Sub
    Sub CreateUpFireball()


        UpFire = New CUpFireProjectile
        ReDim UpFire.ArrSprites(1)
        UpFire.ArrSprites(0) = DownFireBall
        UpFire.ArrSprites(1) = UpFireBall


        ListChar.Add(UpFire)


        If FS.FDir = FaceDir.Left Then

            UpFire.PosX = FS.PosX - 80
            UpFire.FDir = FaceDir.Left

        Else

            UpFire.PosX = FS.PosX + 80
            UpFire.FDir = FaceDir.Right
        End If



        UpFire.PosY = FS.PosY - 3
        'Fire.Vx = 0
        UpFire.Vy = 0

        If FS.FDir = FaceDir.Left Then

            UpFire.Vx = -40
        Else

            UpFire.Vx = 40
        End If


        UpFire.CurrState = UpStateFireballs.Create2



    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        PictureBox1.Refresh()
        second = second + 1
        second2 = second2 + 1
        second3 = second3 + 1
        second4 = second4 + 1

        If second = 3 Then
            MM.State(StateMegaMan.MMStand, 0)
        End If
        If second2 = 3 Then
            'FS.State(StateSplitMushroom.Stand, 6)


        End If

        If second3 = 3 Then
            MegaManRespawn(FS.ArrSprites(FS.IdxArrSprites).Elmt(FS.FrameIdx), FS)
            'second3 = 7
        End If

        For Each CC In ListChar
            CC.Update()
        Next
        'collision part
        If second4 = 3 Then
            MM.Destroy = True
            MM.PosX = 300
            MM.PosY = 900
            second3 = 0
            'second4 = 4
        End If
        x = CollisionDetection(FS.ArrSprites(FS.IdxArrSprites).Elmt(FS.FrameIdx), MM.ArrSprites(MM.IdxArrSprites).Elmt(MM.FrameIdx), FS, MM)
        If x Then
            ' mm.state(statesplitmushroom.mmattacked, 3)
            'MM.State(StateMegaMan.MMGetHit, 3)
            'second4 = 0
            If FS.CurrState <> StateSplitMushroom.Uppercut Or FS.CurrState <> StateSplitMushroom.SmackDown Then
                MM.State(StateMegaMan.MMGetHit, 3)

            End If
        End If


        If FS.CurrState = StateSplitMushroom.Dash And x Then
            FS.doSmackDown = True
            If FS.FDir = FaceDir.Left Then
                FS.FDir = FaceDir.Right
            Else
                FS.FDir = FaceDir.Left
            End If
            FS.State(StateSplitMushroom.UpAttack, 9)
            MM.State(StateMegaMan.MMGetHit, 3)
            MM.Vy = -20
            MM.Vx = 0

            'MM.PosY = MM.PosY + MM.Vy
            ' second4 = 0
        End If


        If CollisionDetection(UpFire.ArrSprites(UpFire.IdxArrSprites).Elmt(UpFire.FrameIdx), MM.ArrSprites(MM.IdxArrSprites).Elmt(MM.FrameIdx), UpFire, MM) Then
            MM.State(StateMegaMan.MMGetBurned, 5)
            UpFire.Destroy = True
            UpFire.PosX = 300
            UpFire.PosY = 800
            second4 = 0
        End If

        If CollisionDetection(DownFire.ArrSprites(DownFire.IdxArrSprites).Elmt(DownFire.FrameIdx), MM.ArrSprites(MM.IdxArrSprites).Elmt(MM.FrameIdx), DownFire, MM) Then
            MM.State(StateMegaMan.MMGetBurned, 5)
            DownFire.Destroy = True
            DownFire.PosX = 300
            DownFire.PosY = 800
            second4 = 0
        End If

        'A = CollisionDetection(MMFire.ArrSprites(MMFire.IdxArrSprites).Elmt(MMFire.FrameIdx), FS.ArrSprites(FS.IdxArrSprites).Elmt(FS.FrameIdx), MMFire, FS)
        If CollisionDetection(MMFire.ArrSprites(MMFire.IdxArrSprites).Elmt(MMFire.FrameIdx), FS.ArrSprites(FS.IdxArrSprites).Elmt(FS.FrameIdx), MMFire, FS) Then

            second2 = 0
            FS.State(StateSplitMushroom.GetHit, 5)

            If MM.FDir = FaceDir.Left Then
                FS.PosX = FS.PosX + 5

            ElseIf MM.FDir = FaceDir.Right Then
                FS.PosX = FS.PosX - 5
            End If

            'A = False
            MMFire.Destroy = True
            MMFire.PosY = 300
            MMFire.PosX = 800

        End If

        'creating fireballs
        If FS.CurrState = StateSplitMushroom.DownAttack And FS.FrameIdx = 9 Then
            CreateDownFireball()
        ElseIf FS.CurrState = StateSplitMushroom.UpAttack And FS.FrameIdx = 5 Then
            CreateUpFireball()
        End If

        If MM.CurrState = StateMegaMan.MMAttack And MM.FrameIdx = 3 Then
            CreateMMFireball()
        End If

        Dim Listchar1 As New List(Of CCharacter)

        For Each CC In ListChar
            If Not CC.Destroy Then
                Listchar1.Add(CC)
            End If
        Next

        ListChar = Listchar1

        DisplayImg()
        FS.Update()
        MM.Update()
        DisplayImg()
        'DisplayImgMegaMan()
    End Sub


End Class
