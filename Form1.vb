Imports System.IO

Public Class Form1

    Dim bmp As Bitmap
    Dim Bg, Bg1, Img As CImage
    Dim SpriteMap As CImage
  Dim SpriteMask As CImage
    Dim FlameStagJump, FlameStagUppercut, FlameStagDeath, FlameStagCharge, FlameStagLanding, FlameStagStand, FlameStagGetHit, FlameStagIntro, FlameStagDownAttack, FlameStagUpAttack, FlameStagDash, FlameStagSmackDown As CArrFrame
    Dim FS As CCharacter

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    'open image for background, assign to bg

    Bg = New CImage
        Bg.OpenImage("background_02.bmp")
        Bg.CopyImg(Img)
        Bg.CopyImg(Bg1)


        SpriteMap = New CImage
        SpriteMap.OpenImage("flamestag.bmp")
        SpriteMap.CreateMask(SpriteMask)

        'initialize sprites
        FlameStagJump = New CArrFrame

        FlameStagJump.Insert(37, 50, 7, 27, 69, 74, 1)
        'FlameStagJump.Insert(95, 43, 78, 13, 116, 74, 1)
        'FlameStagJump.Insert(149, 43, 125, 13, 176, 71, 1)
        'FlameStagJump.Insert(210, 45, 183, 16, 236, 72, 1)
        'FlameStagJump.Insert(284, 41, 252, 13, 304, 70, 1)

        FlameStagLanding = New CArrFrame
        FlameStagLanding.Insert(64, 250, 26, 184, 51, 158, 1)
        FlameStagLanding.Insert(73, 125, 56, 100, 93, 158, 1)
        FlameStagLanding.Insert(124, 139, 98, 115, 147, 157, 1)
        FlameStagLanding.Insert(178, 139, 152, 115, 199, 156, 1)

        FlameStagIntro = New CArrFrame
        FlameStagIntro.Insert(34, 203, 8, 176, 58, 225, 1)
        FlameStagIntro.Insert(95, 203, 71, 176, 120, 225, 1)
        FlameStagIntro.Insert(157, 203, 131, 176, 187, 225, 1)
        FlameStagIntro.Insert(215, 203, 192, 176, 239, 225, 1)
        FlameStagIntro.Insert(273, 203, 245, 183, 300, 225, 1)
        FlameStagIntro.Insert(339, 203, 306, 183, 370, 225, 1)
        FlameStagIntro.Insert(402, 203, 374, 178, 428, 225, 1)
        FlameStagIntro.Insert(461, 203, 431, 179, 484, 225, 1)
        FlameStagIntro.Insert(516, 203, 492, 171, 541, 225, 1)
        FlameStagIntro.Insert(571, 203, 549, 167, 597, 225, 1)
        FlameStagIntro.Insert(622, 203, 606, 158, 645, 225, 1)

        FlameStagDownAttack = New CArrFrame
        FlameStagDownAttack.Insert(32, 267, 9, 238, 56, 288, 1)
        FlameStagDownAttack.Insert(92, 267, 69, 238, 117, 289, 1)
        FlameStagDownAttack.Insert(151, 267, 126, 238, 180, 289, 1)
        FlameStagDownAttack.Insert(213, 267, 188, 240, 243, 289, 1)
        FlameStagDownAttack.Insert(277, 267, 255, 237, 302, 289, 1)
        FlameStagDownAttack.Insert(346, 267, 316, 248, 376, 289, 1)
        FlameStagDownAttack.Insert(415, 267, 381, 248, 446, 289, 1)
        FlameStagDownAttack.Insert(493, 267, 455, 248, 523, 289, 1)
        FlameStagDownAttack.Insert(577, 267, 529, 248, 607, 289, 1)
        FlameStagDownAttack.Insert(672, 267, 616, 248, 703, 289, 1)

        FlameStagUpAttack = New CArrFrame
        FlameStagUpAttack.Insert(41, 330, 12, 308, 66, 355, 1)
        FlameStagUpAttack.Insert(107, 330, 77, 309, 129, 355, 1)
        FlameStagUpAttack.Insert(174, 330, 143, 309, 196, 355, 1)
        FlameStagUpAttack.Insert(242, 330, 211, 303, 264, 355, 1)
        FlameStagUpAttack.Insert(315, 330, 279, 296, 341, 355, 1)
        FlameStagUpAttack.Insert(374, 330, 350, 296, 399, 355, 1)

        FlameStagSmackDown = New CArrFrame
        FlameStagSmackDown.Insert(227, 505, 212, 472, 244, 545, 1)

        FlameStagDash = New CArrFrame
        FlameStagDash.Insert(48, 399, 10, 362, 80, 428, 1)
        FlameStagDash.Insert(134, 399, 96, 362, 165, 428, 1)
        FlameStagDash.Insert(218, 399, 177, 362, 250, 428, 1)
        FlameStagDash.Insert(307, 399, 258, 362, 341, 428, 1)
        FlameStagDash.Insert(405, 399, 347, 362, 437, 428, 1)
        FlameStagDash.Insert(509, 399, 443, 362, 540, 428, 1)
        FlameStagDash.Insert(620, 399, 546, 360, 652, 428, 1)
        FlameStagDash.Insert(739, 399, 657, 360, 770, 428, 1)
        FlameStagDash.Insert(868, 399, 777, 360, 898, 428, 1)
        FlameStagDash.Insert(1002, 399, 905, 360, 1034, 428, 1)

        FlameStagUppercut = New CArrFrame
        FlameStagUppercut.Insert(37, 510, 15, 479, 52, 544, 1)
        FlameStagUppercut.Insert(72, 510, 58, 474, 87, 545, 1)
        FlameStagUppercut.Insert(109, 510, 94, 471, 123, 545, 1)
        FlameStagUppercut.Insert(163, 492, 132, 451, 193, 546, 1)

        FlameStagCharge = New CArrFrame
        FlameStagCharge.Insert(827, 44, 801, 15, 852, 67, 1)
        FlameStagCharge.Insert(880, 44, 857, 16, 906, 67, 1)

        FlameStagDeath = New CArrFrame
        FlameStagDeath.Insert(828, 125, 801, 90, 844, 150, 1)
        FlameStagDeath.Insert(883, 125, 855, 96, 901, 148, 1)

        FlameStagGetHit = New CArrFrame
        FlameStagGetHit.Insert(830, 201, 803, 171, 856, 224, 1)

        FlameStagStand = New CArrFrame
        FlameStagStand.Insert(68, 406, 16, 352, 116, 450, 1)

        FS = New CCharacter
        ReDim FS.ArrSprites(11)

        FS.ArrSprites(0) = FlameStagStand
        FS.ArrSprites(1) = FlameStagUppercut
        FS.ArrSprites(2) = FlameStagDeath
        FS.ArrSprites(3) = FlameStagCharge
        FS.ArrSprites(4) = FlameStagLanding
        FS.ArrSprites(5) = FlameStagStand
        FS.ArrSprites(6) = FlameStagGetHit
        FS.ArrSprites(7) = FlameStagJump
        FS.ArrSprites(8) = FlameStagDownAttack
        FS.ArrSprites(9) = FlameStagUpAttack
        FS.ArrSprites(10) = FlameStagDash
        FS.ArrSprites(11) = FlameStagSmackDown

        FS.PosX = 430
        FS.PosY = 280
        FS.Vx = 0
        FS.Vy = 0
        FS.State(StateSplitMushroom.Intro, 0)
        FS.FDir = FaceDir.Left

        bmp = New Bitmap(Img.Width, Img.Height)


    DisplayImg()
    ResizeImg()




    Timer1.Enabled = True
  End Sub

  Sub PutSprite(ByVal c As CCharacter)

    Dim i, j As Integer
    'set background
    For i = 0 To Img.Width - 1
      For j = 0 To Img.Height - 1
        Img.Elmt(i, j) = Bg1.Elmt(i, j)
      Next
    Next

    Dim EF As CElmtFrame = c.ArrSprites(c.IdxArrSprites).Elmt(c.FrameIdx)
    Dim spritewidth = EF.Right - EF.Left
    Dim spriteheight = EF.Bottom - EF.Top


    If c.FDir = FaceDir.Left Then
      Dim spriteleft As Integer = c.PosX - EF.CtrPoint.x + EF.Left
      Dim spritetop As Integer = c.PosY - EF.CtrPoint.y + EF.Top
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
      Dim spriteleft = c.PosX + EF.CtrPoint.x - EF.Right
      Dim spritetop = c.PosY - EF.CtrPoint.y + EF.Top
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

  End Sub

  Sub DisplayImg()
    'display bg and sprite on picturebox
    Dim i, j As Integer
        PutSprite(FS)

        For i = 0 To Img.Width - 1
      For j = 0 To Img.Height - 1
        bmp.SetPixel(i, j, Img.Elmt(i, j))
      Next
    Next

    PictureBox1.Refresh()

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




  Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

    PictureBox1.Refresh()

        FS.Update()

        DisplayImg()


  End Sub

End Class
