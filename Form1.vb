Imports System.IO
Imports WMPLib
Public Class Form1

    Dim bmp As Bitmap
    Dim Bg, Bg1, Img As CImage
    Dim SpriteMap, SpriteMapMegaMan As CImage
    Dim SpriteMask, SpriteMaskMegaMan As CImage
    Dim DownFireBall, MegamanAttack, MegaManFireBall, MegamanWalk, MegamanStand, UpFireBall, FlameStagJump, FlameStagUppercut, FlameStagDeath, FlameStagCharge, FlameStagLanding, FlameStagStand, FlameStagGetHit, FlameStagIntro, FlameStagDownAttack, FlameStagUpAttack, FlameStagDash, FlameStagSmackDown As CArrFrame
    Dim FS, MM, MMF, FSF As CCharacter
    Dim ListChar As New List(Of CCharacter)

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
        Bg.OpenImage("background_02.bmp")
        Bg.CopyImg(Img)
        Bg.CopyImg(Bg1)


        SpriteMap = New CImage
        SpriteMap.OpenImage("flamestag2.bmp")
        SpriteMap.CreateMask(SpriteMask)

        'initialize sprites
        FlameStagJump = New CArrFrame

        FlameStagJump.Insert(37 * 2, 50 * 2, 7 * 2, 27 * 2, 69 * 2, 74 * 2, 1)
        'FlameStagJump.Insert(95* 2, 43* 2, 78* 2, 13* 2, 116* 2, 74* 2, 1)
        'FlameStagJump.Insert(149* 2, 43* 2, 125* 2, 13* 2, 176* 2, 71* 2, 1)
        'FlameStagJump.Insert(210* 2, 45* 2, 183* 2, 16* 2, 236* 2, 72* 2, 1)
        'FlameStagJump.Insert(284* 2, 41* 2, 252* 2, 13* 2, 304* 2, 70* 2, 1)

        FlameStagLanding = New CArrFrame
        FlameStagLanding.Insert(64 * 2, 250 * 2, 26 * 2, 184 * 2, 51 * 2, 158 * 2, 1)
        FlameStagLanding.Insert(73 * 2, 125 * 2, 56 * 2, 100 * 2, 93 * 2, 158 * 2, 1)
        FlameStagLanding.Insert(124 * 2, 139 * 2, 98 * 2, 115 * 2, 147 * 2, 157 * 2, 1)
        FlameStagLanding.Insert(178 * 2, 139 * 2, 152 * 2, 115 * 2, 199 * 2, 156 * 2, 1)

        FlameStagIntro = New CArrFrame
        FlameStagIntro.Insert(34 * 2, 203 * 2, 8 * 2, 176 * 2, 58 * 2, 225 * 2, 1)
        FlameStagIntro.Insert(95 * 2, 203 * 2, 71 * 2, 176 * 2, 120 * 2, 225 * 2, 1)
        FlameStagIntro.Insert(157 * 2, 203 * 2, 131 * 2, 176 * 2, 187 * 2, 225 * 2, 1)
        FlameStagIntro.Insert(215 * 2, 203 * 2, 192 * 2, 176 * 2, 239 * 2, 225 * 2, 1)
        FlameStagIntro.Insert(273 * 2, 203 * 2, 245 * 2, 183 * 2, 300 * 2, 225 * 2, 1)
        FlameStagIntro.Insert(339 * 2, 203 * 2, 306 * 2, 183 * 2, 370 * 2, 225 * 2, 1)
        FlameStagIntro.Insert(402 * 2, 203 * 2, 374 * 2, 178 * 2, 428 * 2, 225 * 2, 1)
        FlameStagIntro.Insert(461 * 2, 203 * 2, 431 * 2, 179 * 2, 484 * 2, 225 * 2, 1)
        FlameStagIntro.Insert(516 * 2, 203 * 2, 492 * 2, 171 * 2, 541 * 2, 225 * 2, 1)
        FlameStagIntro.Insert(571 * 2, 203 * 2, 549 * 2, 167 * 2, 597 * 2, 225 * 2, 1)
        FlameStagIntro.Insert(622 * 2, 203 * 2, 606 * 2, 158 * 2, 645 * 2, 225 * 2, 1)


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
        FlameStagDash.Insert(48 * 2, 399 * 2, 10 * 2, 362 * 2, 80 * 2, 428 * 2, 1)
        FlameStagDash.Insert(134 * 2, 399 * 2, 96 * 2, 362 * 2, 165 * 2, 428 * 2, 1)
        FlameStagDash.Insert(218 * 2, 399 * 2, 177 * 2, 362 * 2, 250 * 2, 428 * 2, 1)
        FlameStagDash.Insert(307 * 2, 399 * 2, 258 * 2, 362 * 2, 341 * 2, 428 * 2, 1)
        FlameStagDash.Insert(405 * 2, 399 * 2, 347 * 2, 362 * 2, 437 * 2, 428 * 2, 1)
        FlameStagDash.Insert(509 * 2, 399 * 2, 443 * 2, 362 * 2, 540 * 2, 428 * 2, 1)
        FlameStagDash.Insert(620 * 2, 399 * 2, 546 * 2, 360 * 2, 652 * 2, 428 * 2, 1)
        FlameStagDash.Insert(739 * 2, 399 * 2, 657 * 2, 360 * 2, 770 * 2, 428 * 2, 1)
        FlameStagDash.Insert(868 * 2, 399 * 2, 777 * 2, 360 * 2, 898 * 2, 428 * 2, 1)
        FlameStagDash.Insert(1002 * 2, 399 * 2, 905 * 2, 360 * 2, 1034 * 2, 428 * 2, 1)

        FlameStagUppercut = New CArrFrame
        FlameStagUppercut.Insert(37 * 2, 510 * 2, 15, 479, 52, 544, 1)
        FlameStagUppercut.Insert(72 * 2, 510 * 2, 58, 474, 87, 545, 1)
        FlameStagUppercut.Insert(109 * 2, 510 * 2, 94, 471, 123, 545, 1)
        FlameStagUppercut.Insert(163 * 2, 492 * 2, 132, 451, 193, 546, 1)

        FlameStagCharge = New CArrFrame
        FlameStagCharge.Insert(827 * 2, 44 * 2, 801 * 2, 15 * 2, 852 * 2, 67 * 2, 1)
        FlameStagCharge.Insert(880 * 2, 44 * 2, 857 * 2, 16 * 2, 906 * 2, 67 * 2, 1)

        FlameStagDeath = New CArrFrame
        FlameStagDeath.Insert(1656, 250, 1602, 180, 1688, 300, 1)
        FlameStagDeath.Insert(1666, 250, 1710, 192, 1802, 296, 1)

        FlameStagGetHit = New CArrFrame
        FlameStagGetHit.Insert(1660, 402, 1606, 342, 1712, 448, 1)

        FlameStagStand = New CArrFrame
        FlameStagStand.Insert(68, 406, 16, 352, 116, 450, 1)

        DownFireBall = New CArrFrame
        DownFireBall.Insert(604, 483, 593, 473, 618, 493, 1)
        DownFireBall.Insert(633, 483, 623, 473, 650, 491, 1)
        DownFireBall.Insert(667, 483, 655, 472, 681, 493, 1)
        DownFireBall.Insert(696, 483, 686, 471, 711, 490, 1)

        UpFireBall = New CArrFrame
        UpFireBall.Insert(724, 527, 717, 517, 732, 545, 1)
        UpFireBall.Insert(743, 527, 736, 517, 750, 545, 1)
        UpFireBall.Insert(762, 527, 755, 517, 769, 545, 1)
        UpFireBall.Insert(781, 527, 774, 517, 790, 545, 1)

        MegamanStand = New CArrFrame
        MegamanStand.Insert(27, 32, 7, 7, 43, 49, 1)

        MegamanWalk = New CArrFrame
        MegamanWalk.Insert(19, 83, 4, 59, 33, 99, 1)
        MegamanWalk.Insert(57, 83, 38, 59, 74, 99, 1)
        MegamanWalk.Insert(106, 83, 79, 59, 128, 99, 1)
        MegamanWalk.Insert(155, 83, 134, 59, 171, 99, 1)
        MegamanWalk.Insert(194, 83, 180, 59, 210, 99, 1)
        MegamanWalk.Insert(230, 83, 217, 61, 245, 99, 1)
        MegamanWalk.Insert(272, 83, 257, 60, 286, 99, 1)
        MegamanWalk.Insert(319, 83, 298, 60, 338, 99, 1)
        MegamanWalk.Insert(363, 83, 348, 60, 380, 99, 1)
        MegamanWalk.Insert(404, 83, 391, 61, 419, 99, 1)

        MegamanAttack = New CArrFrame
        MegamanAttack.Insert(24, 141, 3, 117, 40, 157, 1)
        MegamanAttack.Insert(68, 141, 45, 116, 92, 157, 1)
        MegamanAttack.Insert(120, 141, 97, 116, 146, 157, 1)
        MegamanAttack.Insert(173, 141, 151, 115, 196, 156, 1)

        MegaManFireBall = New CArrFrame
        MegaManFireBall.Insert(214, 135, 208, 130, 219, 139, 1)

        MM = New CCharacter
        ReDim MM.ArrSprites(2)
        MM.ArrSprites(0) = MegamanWalk
        MM.ArrSprites(1) = MegamanStand
        MM.ArrSprites(2) = MegamanAttack


        FS = New CCharacter
        ReDim FS.ArrSprites(11)

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

        FS.PosX = 430
        FS.PosY = 290
        FS.Vx = 0
        FS.Vy = 0
        FS.State(StateSplitMushroom.Intro, 0)
        FS.FDir = FaceDir.Left

        bmp = New Bitmap(Img.Width, Img.Height)
        ListChar.Add(FS)
        MM.PosX = 230
        MM.PosY = 280
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

            If cc.FDir = FaceDir.Left Then
                Dim spriteleft As Integer = cc.PosX - EF.CtrPoint.x + EF.Left
                Dim spritetop As Integer = cc.PosY - EF.CtrPoint.y + EF.Top
                'set mask
                For i = 0 To spritewidth
                    For j = 0 To spriteheight
                        Img.Elmt(spriteleft + i, spritetop + j) = OpAnd(Img.Elmt(spriteleft + i, spritetop + j), SpriteMask.Elmt(EF.Left + i, EF.Top + j))
                    Next
                Next

                'set sprite
                For i = 0 To spritewidth
                    For j = 0 To spriteheight
                        Img.Elmt(spriteleft + i, spritetop + j) = OpOr(Img.Elmt(spriteleft + i, spritetop + j), SpriteMap.Elmt(EF.Left + i, EF.Top + j))
                    Next
                Next
            Else 'facing right
                Dim spriteleft = cc.PosX + EF.CtrPoint.x - EF.Right
                Dim spritetop = cc.PosY - EF.CtrPoint.y + EF.Top
                'set mask
                For i = 0 To spritewidth
                    For j = 0 To spriteheight
                        Img.Elmt(spriteleft + i, spritetop + j) = OpAnd(Img.Elmt(spriteleft + i, spritetop + j), SpriteMask.Elmt(EF.Right - i, EF.Top + j))
                    Next
                Next

                'set sprite
                For i = 0 To spritewidth
                    For j = 0 To spriteheight
                        Img.Elmt(spriteleft + i, spritetop + j) = OpOr(Img.Elmt(spriteleft + i, spritetop + j), SpriteMap.Elmt(EF.Right - i, EF.Top + j))
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
                FS.Vx = -10
                FS.Vy = -2
                FS.State(StateSplitMushroom.Jump, 7)
            ElseIf FS.FDir = FaceDir.Right Then
                FS.Vx = 10
                FS.Vy = -2
                FS.State(StateSplitMushroom.Jump, 7)

            End If
        End If
        'detect down arrow key
        If keyData = Keys.Down Then
            If FS.PosY = 290 Then
                FS.State(StateSplitMushroom.Stand, 6)
            End If
        End If

        'detect left arrow key
        If keyData = Keys.Left Then 'dash left
            If FS.PosY >= 290 Then
                FS.PosY = 290
                FS.FDir = FaceDir.Right
                FS.Vx = -10

                FS.State(StateSplitMushroom.Charge, 3)

            End If
        End If

        'detect right arrow key
        If keyData = Keys.Right Then ' dash right
            If FS.PosY >= 290 Then
                FS.PosY = 290
                FS.State(StateSplitMushroom.Charge, 3)
                FS.FDir = FaceDir.Left
                FS.Vx = 10
            End If
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim input As String
        input = e.KeyCode
        Select Case input
            Case 32 'spacebar
                If FS.PosY >= 290 Then
                    FS.PosY = 290
                    FS.State(StateSplitMushroom.DownAttack, 8)
                    If FS.CurrState = StateSplitMushroom.DownAttack And FS.CurrFrame = 10 Then
                        'CreateFireBall(1)
                    End If

                End If

        End Select
    End Sub
    ' Sub CreateFireball(i As Integer)
    'Dim Fire As StateFireballs
    '    Fire = New StateFireballs
    'If FS.FDir = FaceDir.Left Then
    '        Fire.PosX = FS.PosX - 20
    '       Fire.FDir = FaceDir.Left
    'Else
    '       SP.PosX = SM.PosX + 20
    '       SP.FDir = FaceDir.Right
    'End If
    ' End Sub

End Class
