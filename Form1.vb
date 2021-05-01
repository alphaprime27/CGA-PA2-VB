Imports System.IO
Imports WMPLib
Public Class Form1

    Dim bmp As Bitmap
    Dim Bg, Bg1, Img As CImage
    Dim SpriteMap, SpriteMapMegaMan As CImage
    Dim SpriteMask, SpriteMaskMegaMan As CImage
    Dim DownFireBall, MegamanAttacked, MegamanAttack, MegaManFireBall, MegamanWalk, MegamanStand, UpFireBall, FlameStagJump, FlameStagStanceOnTheGround, FlameStagUppercut, FlameStagStanceOnTheWall, FlameStagDeath, FlameStagCharge, FlameStagLanding, FlameStagStand, FlameStagGetHit, FlameStagIntro, FlameStagDownAttack, FlameStagUpAttack, FlameStagDash, FlameStagSmackDown As CArrFrame
    Dim FS, MM, MMF, FSF As CCharacter
    Dim ListChar As New List(Of CCharacter)
    Dim x As Boolean


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
        SpriteMap.OpenImage("flamestag2.bmp")
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
        FlameStagDownAttack.Insert(32 * 2, 267 * 2, 9 * 2, 238 * 2, 56 * 2, 288 * 2, 1)
        FlameStagDownAttack.Insert(92 * 2, 267 * 2, 69 * 2, 238 * 2, 117 * 2, 289 * 2, 1)
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
        FlameStagSmackDown.Insert(227, 505, 212, 472, 244, 545, 1)

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
        FlameStagUppercut.Insert(38 * 2, 510 * 2, 15, 479, 52, 544, 1)
        FlameStagUppercut.Insert(72 * 2, 510 * 2, 58, 474, 87, 545, 1)
        FlameStagUppercut.Insert(108 * 2, 510 * 2, 94, 471, 123, 545, 1)
        FlameStagUppercut.Insert(163 * 2, 492 * 2, 132, 451, 193, 546, 1)

        FlameStagCharge = New CArrFrame
        FlameStagCharge.Insert(827 * 2, 44 * 2, 801 * 2, 15 * 2, 852 * 2, 67 * 2, 5)
        FlameStagCharge.Insert(880 * 2, 44 * 2, 857 * 2, 16 * 2, 906 * 2, 67 * 2, 5)

        FlameStagDeath = New CArrFrame
        FlameStagDeath.Insert(1656, 250, 1602, 180, 1688, 300, 1)
        FlameStagDeath.Insert(1666, 250, 1710, 192, 1802, 296, 1)

        FlameStagGetHit = New CArrFrame
        FlameStagGetHit.Insert(977, 45, 950, 14, 1003, 68, 1)

        FlameStagStand = New CArrFrame
        FlameStagStand.Insert(68, 406, 16, 352, 116, 450, 1)
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

        MegamanAttacked = New CArrFrame
        MegamanAttacked.Insert(35 * 2, 776 * 2, 18 * 2, 748 * 2, 55 * 2, 793 * 2, 1)
        MegamanAttacked.Insert(80 * 2, 776 * 2, 61 * 2, 748 * 2, 104 * 2, 792 * 2, 1)
        MegamanAttacked.Insert(133 * 2, 776 * 2, 111 * 2, 748 * 2, 154 * 2, 792 * 2, 1)
        MegamanAttacked.Insert(183 * 2, 776 * 2, 162 * 2, 749 * 2, 205 * 2, 788 * 2, 1)

        MM = New CCharacter
        ReDim MM.ArrSprites(3)
        MM.ArrSprites(0) = MegamanStand
        MM.ArrSprites(1) = MegamanWalk
        MM.ArrSprites(2) = MegamanAttack
        MM.ArrSprites(3) = MegamanAttacked

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

        FS.PosX = 460
        FS.PosY = 340
        FS.Vx = 0
        FS.Vy = 0
        FS.State(StateSplitMushroom.Intro, 0)
        FS.FDir = FaceDir.Left

        bmp = New Bitmap(Img.Width, Img.Height)
        ListChar.Add(FS)
        MM.PosX = 150
        MM.PosY = 340
        MM.Vx = 0
        MM.Vy = 0
        MM.State(StateSplitMushroom.Intro, 0)
        MM.FDir = FaceDir.Left
        ListChar.Add(MM)
        'bmp2 = New Bitmap(Img.Width, Img.Height)

        DisplayImg()
        'DisplayImgMegaMan()
        ResizeImg()

        Timer1.Enabled = True

    End Sub
    Public Function CollisionDetection(frame1 As CElmtFrame, frame2 As CElmtFrame, object1 As CCharacter, object2 As CCharacter)
        Dim L1, L2, R1, R2, T1, T2, B1, B2 As Integer

        L1 = frame1.Left - frame1.CtrPoint.x + object1.PosX
        R1 = frame1.Right - frame1.CtrPoint.x + object1.PosX
        T1 = frame1.Top - frame1.CtrPoint.y + object1.PosY
        B1 = frame1.Bottom - frame1.CtrPoint.y + object1.PosY

        L2 = frame2.Left - frame2.CtrPoint.x + object2.PosX
        R2 = frame2.Right - frame2.CtrPoint.x + object2.PosX
        T2 = frame2.Top - frame2.CtrPoint.y + object2.PosY
        B2 = frame2.Bottom - frame2.CtrPoint.y + object2.PosY

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
        For Each cc In ListChar

            Dim EF As CElmtFrame = cc.ArrSprites(cc.IdxArrSprites).Elmt(cc.FrameIdx)

            Dim spritewidth = EF.Right - EF.Left
            Dim spriteheight = EF.Bottom - EF.Top
            Dim imgx, imgy As Integer
            Dim scrX, scrY As Integer


            If cc.FDir = FaceDir.Left Then
                Dim spriteleft As Integer = cc.PosX - EF.CtrPoint.x + EF.Left
                Dim spritetop As Integer = cc.PosY - EF.CtrPoint.y + EF.Top
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
                Dim spritetop = cc.PosY - EF.CtrPoint.y + EF.Top
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

    'Sub DisplayImgMegaMan()
    '    'display bg and sprite on picturebox
    '    Dim i, j As Integer
    '    PutSpriteMegaMan(MM)

    '    For i = 0 To Img.Width - 1
    '        For j = 0 To Img.Height - 1
    '            bmp.SetPixel(i, j, Img.Elmt(i, j))
    '        Next
    '    Next


    '    PictureBox1.Image = bmp
    '    PictureBox1.Width = bmp.Width
    '    PictureBox1.Height = bmp.Height
    '    PictureBox1.Top = 0
    '    PictureBox1.Left = 0
    '    'Me.Width = PictureBox1.Width + 30
    '    'Me.Height = PictureBox1.Height + 100

    'End Sub

    Sub ResizeImg()
        Dim w, h As Integer
        w = PictureBox1.Width
        h = PictureBox1.Height
        Me.ClientSize = New Size(w, h)

    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        PictureBox1.Refresh()

        For Each CC In ListChar
            CC.Update()


        Next
        x = CollisionDetection(FS.ArrSprites(FS.IdxArrSprites).Elmt(FS.FrameIdx), MM.ArrSprites(MM.IdxArrSprites).Elmt(MM.FrameIdx), FS, MM)
        If x Then
            ' MM.State(StateSplitMushroom.MMAttacked, 3)
            MM.PosX = 400
        End If
        If FS.CurrState = StateSplitMushroom.DownAttack And FS.FrameIdx = 5 Then
            CreateFireball(1)
        ElseIf FS.CurrState = StateSplitMushroom.UpAttack And FS.FrameIdx = 3 Then
            CreateFireball(2)
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
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        'detect up arrow key
        If keyData = Keys.Up Then
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
        'detect down arrow key
        If keyData = Keys.Down Then
            If FS.PosY = 340 Then
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
        If keyData = Keys.Left Then 'dash left
            If FS.PosY >= 340 Then
                FS.PosY = 340
                FS.FDir = FaceDir.Left
                FS.Vx = -50

                FS.State(StateSplitMushroom.Charge, 3)

            End If
        End If

        'detect right arrow key
        If keyData = Keys.Right Then ' dash right
            If FS.PosY >= 340 Then
                FS.PosY = 340
                FS.FDir = FaceDir.Right
                FS.State(StateSplitMushroom.Charge, 3)

                FS.Vx = 50
            End If
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim input As String
        input = e.KeyCode
        Select Case input
            Case 32 'spacebar
                If FS.PosY >= 340 Then
                    FS.PosY = 340
                    FS.State(StateSplitMushroom.DownAttack, 8)

                End If

        End Select
    End Sub
    Sub CreateFireball(i As Integer)

        Dim Fire As CFireProjectile
        Fire = New CFireProjectile
        If FS.FDir = FaceDir.Left Then
            Fire.PosX = FS.PosX - 52
            Fire.FDir = FaceDir.Left
        Else
            Fire.PosX = FS.PosX + 52
            Fire.FDir = FaceDir.Right
        End If
        Fire.PosY = FS.PosY - 3
        Fire.Vx = 0
        Fire.Vy = 0

        ReDim Fire.ArrSprites(2)
        If i = 1 Then
            Fire.CurrState = StateFireballs.Create
        Else
            Fire.CurrState = StateFireballs.Create2
        End If
        Fire.ArrSprites(0) = DownFireBall
        Fire.ArrSprites(1) = UpFireBall


        ListChar.Add(Fire)

    End Sub





End Class
