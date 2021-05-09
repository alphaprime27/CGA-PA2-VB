Imports System.IO

Public Enum StateFlameStag
    Intro
    Jump
    JumpDown
    Uppercut
    Death
    Charge
    Landing
    Stand
    GetHit
    DownAttack
    UpAttack
    Dash
    SmackDown
    Fall
    ChangeStance
    JumpStance
End Enum

Public Enum StateMegaMan
    MMStand
    MMWalk
    MMAttack
    MMGetHit
    MMGetBurned
    MMGetSmackedDown
    MMGetUppercutted
End Enum
'FlameStagJump, FlameStagUppercut, FlameStagDeath, FlameStagCharge, FlameStagLanding, FlameStagStand, FlameStagGetHit,
'FlameStagIntro, FlameStagDownAttack, FlameStagUpAttack, FlameStagDash, FlameStagSmackDown
Public Enum FaceDir
    Left
    Right
End Enum
Public Enum DownStateFireballs
    Create
    Go
    Destroy

End Enum

Public Enum UpStateFireballs
    Create2
    Go2
    ClimbUp
    Destroy
End Enum


Public Enum StateMMFireballs
    CreateMM
    GoMM
    Destroy
End Enum


Public Class CImage
    Public Width As Integer
    Public Height As Integer
    Public Elmt(,) As System.Drawing.Color
    Public ColorMode As Integer 'not used

    Sub OpenImage(ByVal FName As String)
        Dim s As String
        Dim L As Long
        Dim BR As BinaryReader
        Dim h, w, pos As Integer
        Dim r, g, b As Integer
        Dim pad As Integer

        BR = New BinaryReader(File.Open(FName, FileMode.Open))

        Try
            BlockRead(BR, 2, s)

            If s <> "BM" Then
                MsgBox("Not a BMP file")
            Else 'BMP file
                BlockReadInt(BR, 4, L) 'size
                'MsgBox("Size = " + CStr(L))
                BlankRead(BR, 4) 'reserved
                BlockReadInt(BR, 4, pos) 'start of data
                BlankRead(BR, 4) 'size of header
                BlockReadInt(BR, 4, Width) 'width
                'MsgBox("Width = " + CStr(I.Width))
                BlockReadInt(BR, 4, Height) 'height
                'MsgBox("Height = " + CStr(I.Height))
                BlankRead(BR, 2) 'color panels
                BlockReadInt(BR, 2, ColorMode) 'colormode
                If ColorMode <> 24 Then
                    MsgBox("Not a 24-bit color BMP")
                Else

                    BlankRead(BR, pos - 30)

                    ReDim Elmt(Width - 1, Height - 1)
                    pad = (4 - (Width * 3 Mod 4)) Mod 4

                    For h = Height - 1 To 0 Step -1
                        For w = 0 To Width - 1
                            BlockReadInt(BR, 1, b)
                            BlockReadInt(BR, 1, g)
                            BlockReadInt(BR, 1, r)
                            Elmt(w, h) = Color.FromArgb(r, g, b)

                        Next
                        BlankRead(BR, pad)

                    Next

                End If

            End If

        Catch ex As Exception
            MsgBox("Error")

        End Try

        BR.Close()


    End Sub


    Sub CreateMask(ByRef Mask As CImage)
        Dim i, j As Integer

        Mask = New CImage
        Mask.Width = Width
        Mask.Height = Height

        ReDim Mask.Elmt(Mask.Width - 1, Mask.Height - 1)

        For i = 0 To Width - 1
            For j = 0 To Height - 1
                If Elmt(i, j).R = 0 And Elmt(i, j).G = 0 And Elmt(i, j).B = 0 Then
                    Mask.Elmt(i, j) = Color.FromArgb(255, 255, 255)
                Else
                    Mask.Elmt(i, j) = Color.FromArgb(0, 0, 0)
                End If
            Next
        Next

    End Sub


    Sub CopyImg(ByRef Img As CImage)
        'copies image to Img
        Img = New CImage
        Img.Width = 605
        Img.Height = 440
        ReDim Img.Elmt(Width - 1, Height - 1)

        For i = 0 To Width - 1
            For j = 0 To Height - 1
                Img.Elmt(i, j) = Elmt(i, j)
            Next
        Next

    End Sub

End Class
Public Class character
    Public Overridable Sub Update()

    End Sub
End Class

Public Class CFlameStag
    Inherits character
    Public PosX, PosY As Double
    Public Vx, Vy As Double
    Public CurrState As StateFlameStag
    Public FrameIdx As Integer
    Public CurrFrame As Integer
    Public ArrSprites() As CArrFrame
    Public IdxArrSprites As Integer
    Public FDir As FaceDir
    Public Destroy As Boolean = False
    Public godown As Boolean = False
    Public dointro As Boolean = False
    Public doUppercut As Boolean = False
    Public doSmackDown As Boolean = False

    Public Sub State(state As StateFlameStag, idxspr As Integer)
        CurrState = state
        IdxArrSprites = idxspr
        CurrFrame = 0
        FrameIdx = 0

    End Sub

    Public Sub GetNextFrame()
        CurrFrame = CurrFrame + 1
        If CurrFrame = ArrSprites(IdxArrSprites).Elmt(FrameIdx).MaxFrameTime Then
            FrameIdx = FrameIdx + 1
            If FrameIdx = ArrSprites(IdxArrSprites).N Then
                FrameIdx = 0
            End If
            CurrFrame = 0

        End If

    End Sub

    Public Sub GetNextMove(a As StateFlameStag, idx As Integer)
        CurrFrame = CurrFrame + 1
        If CurrFrame = ArrSprites(IdxArrSprites).Elmt(FrameIdx).MaxFrameTime Then
            FrameIdx = FrameIdx + 1
            If FrameIdx = ArrSprites(IdxArrSprites).N Then
                CurrFrame = 0
                FrameIdx = 0
                State(a, idx)
            End If
            CurrFrame = 0

        End If
    End Sub

    Public Overrides Sub Update()
        Select Case CurrState

            Case StateFlameStag.Intro '===============================>'INTRO 0
                GetNextFrame()
                If FrameIdx = 9 And CurrFrame = 1 Then
                    State(StateFlameStag.Stand, 6)
                End If

            Case StateFlameStag.Jump '=================================>'JUMP 7
                PosX = PosX + Vx
                PosY = PosY + Vy
                'Vy = Vy + 0.2
                Vy = -30


                GetNextFrame()
                If PosX >= 503 Then
                    PosX = 503
                    State(StateFlameStag.ChangeStance, 13)
                    'FDir = FaceDir.Left

                    Vx = -90
                    'Vy = -90


                End If
                If PosX <= 100 Then
                    PosX = 100
                    State(StateFlameStag.ChangeStance, 13)
                    'FDir = FaceDir.Right
                    Vx = 90
                    ' Vy = -90


                End If

                If PosY < 50 Then
                    godown = True

                End If
                If PosY >= 710 Then
                    PosY = 710
                    State(StateFlameStag.Landing, 4)
                    Vx = 0
                    Vy = 0

                End If
            Case StateFlameStag.ChangeStance ' ========================================> CHANGE STANCE 13
                PosY = PosY + Vy
                Vy = 0.3
                If godown = True Then
                    GetNextFrame()
                    If FrameIdx = 0 And CurrFrame = 0 Then

                        If PosX >= 503 Then
                            PosX = 490
                            Vx = -90

                            FDir = FaceDir.Left
                        ElseIf PosX <= 100 Then
                            PosX = 110
                            Vx = 90

                            FDir = FaceDir.Right
                        End If
                        Vy = 10
                        State(StateFlameStag.JumpDown, 7)
                    End If
                ElseIf doUppercut = True Then
                    GetNextFrame()
                    If FrameIdx = 1 And CurrFrame = 0 Then

                        If PosX >= 503 Then
                            PosX = 503
                            Vx = 0
                            Vy = -20
                            FDir = FaceDir.Right

                        ElseIf PosX <= 100 Then
                            PosX = 100
                            Vx = 0
                            Vy = -20
                            FDir = FaceDir.Left
                        End If
                        State(StateFlameStag.Uppercut, 1)
                    End If


                Else
                    GetNextFrame()
                    If FrameIdx = 0 And CurrFrame = 0 Then
                        State(StateFlameStag.Jump, 7)
                        If FDir = FaceDir.Left Then
                            FDir = FaceDir.Right
                        Else
                            FDir = FaceDir.Left
                        End If
                    End If
                End If

            Case StateFlameStag.Uppercut ' ========================================> UPPERCUT 1 
                GetNextFrame()
                Vy = -53
                PosY = PosY + Vy
                If PosY < 90 And doSmackDown = True Then
                    Vy = 120
                    State(StateFlameStag.SmackDown, 11)
                ElseIf PosY < 90 Then
                    If PosX >= 503 Then
                        PosX = 503

                        FDir = FaceDir.Right
                    ElseIf PosX <= 100 Then
                        PosX = 100

                        FDir = FaceDir.Left
                    End If
                    godown = True
                    doUppercut = False
                    State(StateFlameStag.ChangeStance, 13)
                    FrameIdx = 3


                End If
            Case StateFlameStag.SmackDown ' ========================================> SMACK DOWN 11
                GetNextFrame()
                PosY = PosY + Vy


                If PosY > 710 Then
                    State(StateFlameStag.Stand, 6)
                    Vx = 0
                    Vy = 0
                    PosY = 710
                    doSmackDown = False

                End If


            Case StateFlameStag.Fall ' ========================================> FALL 2
                GetNextFrame()
                PosX = PosX + Vx
                PosY = PosY + Vy
                Vx = 0
                Vy = 50
                If PosY > 710 Then
                    State(StateFlameStag.Stand, 6)
                    Vx = 0
                    Vy = 0
                    PosY = 710
                End If
            Case StateFlameStag.Dash ' ========================================> DASH 10
                PosX = PosX + Vx
                GetNextFrame()


                If PosX >= 503 Then
                    FDir = FaceDir.Left
                    PosX = 490
                    State(StateFlameStag.Stand, 6)



                End If
                If PosX <= 100 Then
                    PosX = 110
                    State(StateFlameStag.Stand, 6)
                    FDir = FaceDir.Right

                End If
            Case StateFlameStag.DownAttack ' ========================================> DOWN ATTACK 8

                GetNextMove(StateFlameStag.UpAttack, 9)


            Case StateFlameStag.UpAttack ' ========================================> UP ATTACK 9
                GetNextFrame()
                If doSmackDown = True Then
                    Vx = 0
                    Vy = -20
                    If FrameIdx = 0 And CurrFrame = 0 Then
                        If FDir = FaceDir.Left Then
                            FDir = FaceDir.Right
                        Else
                            FDir = FaceDir.Left
                        End If
                        State(StateFlameStag.Uppercut, 1)
                    End If
                Else
                    If FrameIdx = 0 And CurrFrame = 0 Then
                        State(StateFlameStag.Stand, 6)
                    End If

                End If
            Case StateFlameStag.Landing ' ========================================> LANDING 4
                GetNextFrame()
                If godown = True Then
                    If dointro = True Then
                        State(StateFlameStag.Intro, 0)
                        godown = False
                        dointro = False
                    ElseIf dointro = False Then
                        godown = False
                        State(StateFlameStag.Stand, 6)
                    End If
                End If

            Case StateFlameStag.Charge ' ========================================> CHARGE 3
                GetNextFrame()
                'State(StateFlameStag.Dash, 10)
                If FrameIdx = 1 And CurrFrame = 4 Then
                    If FDir = FaceDir.Left Then
                        FDir = FaceDir.Right
                        State(StateFlameStag.Dash, 10)
                    Else
                        FDir = FaceDir.Left
                        State(StateFlameStag.Dash, 10)
                    End If
                End If



            Case StateFlameStag.JumpDown ' ========================================> JUMP DOWN 7
                GetNextFrame()
                PosX = PosX + Vx
                PosY = PosY + Vy
                Vy = 15

                If PosX >= 503 Then
                    PosX = 503
                    Vx = -90
                    'Vy = 8
                    FDir = FaceDir.Right
                    State(StateFlameStag.ChangeStance, 13)

                End If


                If PosX <= 100 Then
                    PosX = 100
                    Vx = 90
                    'Vy = 8
                    State(StateFlameStag.ChangeStance, 13)
                    FDir = FaceDir.Left



                End If
                If PosY > 710 Then
                    State(StateFlameStag.Landing, 4)
                    Vx = 0
                    Vy = 0
                    PosY = 710
                End If



            Case StateFlameStag.JumpStance ' ========================================> JUMP STANCE 12
                GetNextMove(StateFlameStag.Jump, 7)

            Case StateFlameStag.GetHit ' ========================================> JUMP STANCE 12

                If FrameIdx = 0 And CurrFrame = 4 Then
                    State(StateFlameStag.Stand, 6)
                End If
                GetNextFrame()
        End Select

    End Sub



End Class
Public Class CDownFireProjectile
    Inherits CFlameStag
    Public CurrState As DownStateFireballs
    Public Overloads Sub State(state As DownStateFireballs, idxspr As Integer)
        CurrState = state
        IdxArrSprites = idxspr
        CurrFrame = 0
        FrameIdx = 0
    End Sub
    Public Overrides Sub Update()
        Select Case CurrState

            Case DownStateFireballs.Create
                GetNextFrame()
                PosX = PosX + Vx

                State(DownStateFireballs.Go, 0)

            Case DownStateFireballs.Go
                GetNextFrame()
                PosX = PosX + Vx
                If FDir = FaceDir.Left And PosX <= 80 Or FDir = FaceDir.Right And PosX >= 510 Then
                    Destroy = True
                    PosX = 300
                    PosY = 800
                End If
                If FDir = FaceDir.Left Then
                    Vx = -40
                Else
                    Vx = 40
                End If




        End Select
    End Sub

End Class


Public Class CUpFireProjectile
    Inherits CFlameStag
    Public CurrState As UpStateFireballs
    Public Overloads Sub State(state As UpStateFireballs, idxspr As Integer)
        CurrState = state
        IdxArrSprites = idxspr
        CurrFrame = 0
        FrameIdx = 0
    End Sub
    Public Overrides Sub Update()
        Select Case CurrState

            Case UpStateFireballs.Create2
                GetNextFrame()
                PosX = PosX + Vx
                State(UpStateFireballs.Go2, 0)

            Case UpStateFireballs.Go2
                GetNextFrame()
                PosX = PosX + Vx
                If FDir = FaceDir.Left And PosX <= 90 Or FDir = FaceDir.Right And PosX >= 510 Then
                    State(UpStateFireballs.ClimbUp, 1)
                End If
                If FDir = FaceDir.Left Then
                    Vx = -40
                Else
                    Vx = 40
                End If
            Case UpStateFireballs.ClimbUp
                GetNextFrame()

                PosY = PosY + Vy
                Vy = -40
                If PosY < -50 Then
                    Destroy = True
                End If



        End Select
    End Sub

End Class

Public Class CMMFireProjectile
    Inherits CFlameStag
    Public CurrState As StateMMFireballs
    Public Overloads Sub State(state As StateMMFireballs, idxspr As Integer)
        CurrState = state
        IdxArrSprites = idxspr
        CurrFrame = 0
        FrameIdx = 0
    End Sub

    Public Overrides Sub Update()
        Select Case CurrState

            Case StateMMFireballs.CreateMM
                GetNextFrame()
                PosX = PosX + Vx
                State(StateMMFireballs.GoMM, 0)

            Case StateMMFireballs.GoMM
                GetNextFrame()
                PosX = PosX + Vx
                If FDir = FaceDir.Left And PosX <= 80 Or FDir = FaceDir.Right And PosX >= 510 Then
                    Destroy = True
                End If
                If FDir = FaceDir.Left Then
                    Vx = -40
                Else
                    Vx = 40
                End If

        End Select
    End Sub

End Class
Public Class CMegamen ' =========================>Megamen
    Inherits CFlameStag
    Public HitAnimation As Boolean = False
    Public HitGround As Boolean = False

    Public Overloads Sub State(state As StateMegaMan, idxspr As Integer)
        CurrState = state
        IdxArrSprites = idxspr
        CurrFrame = 0
        FrameIdx = 0

    End Sub

    Public Overloads Sub GetNextMove(a As StateMegaMan, idx As Integer)
        CurrFrame = CurrFrame + 1
        If CurrFrame = ArrSprites(IdxArrSprites).Elmt(FrameIdx).MaxFrameTime Then
            FrameIdx = FrameIdx + 1
            If FrameIdx = ArrSprites(IdxArrSprites).N Then
                CurrFrame = 0
                FrameIdx = 0
                State(a, idx)
            End If
            CurrFrame = 0

        End If
    End Sub
    Public Overrides Sub Update()
        Select Case CurrState

            Case StateMegaMan.MMStand
                GetNextFrame()
                'PosX = PosX

            Case StateMegaMan.MMWalk
                If FrameIdx = 4 And CurrFrame = 1 Then
                    State(StateMegaMan.MMStand, 0)
                End If

                GetNextFrame()
                'GetNextFrame()

            Case StateMegaMan.MMAttack
                GetNextMove(StateMegaMan.MMStand, 0)
                'GetNextFrame()

            Case StateMegaMan.MMGetUppercutted
                If PosY < 235 Then
                    State(StateMegaMan.MMGetSmackedDown, 7)
                End If
                Vy = -30
                Vx = 0

                PosX = PosX + Vx
                PosY = PosY + Vy

                GetNextFrame()


            Case StateMegaMan.MMGetSmackedDown
                Vy = 120
                Vx = 0
                PosX = PosX + Vx
                PosY = PosY + Vy


                GetNextFrame()
                If PosY >= 720 Then
                    State(StateMegaMan.MMGetHit, 3)
                End If
            Case StateMegaMan.MMGetHit

                PosX = PosX + Vx
                PosY = PosY + Vy
                Vy = Vy + 0.4

                GetNextFrame()

                If HitAnimation = True Then
                    If PosX < 300 Then
                        Vx = Vx + 1
                        Vy = Vy + 1
                        HitGround = True
                    Else
                        Vx = Vx - 1
                        Vy = Vy + 1
                        HitGround = True
                    End If

                    If PosY > 720 Then
                        PosY = 720
                        Vx = 0
                        Vy = 0
                        HitAnimation = False
                        State(StateMegaMan.MMStand, 0)
                    End If
                ElseIf PosY >= 720 And PosX < 300 Then
                    PosY = 720
                    Vx = 10
                    Vy = -10
                    FDir = FaceDir.Right
                    HitAnimation = True

                ElseIf PosY >= 720 And PosX >= 300 Then
                    PosY = 720
                    Vx = -10
                    Vy = -10
                    FDir = FaceDir.Left
                    HitAnimation = True

                End If



            Case StateMegaMan.MMGetBurned
                GetNextFrame()

        End Select


    End Sub

End Class

Public Class CElmtFrame
  Public CtrPoint As TPoint
  Public Top, Bottom, Left, Right As Integer
  Public Idx As Integer
  Public MaxFrameTime As Integer

  Public Sub New(ctrx As Integer, ctry As Integer, l As Integer, t As Integer, r As Integer, b As Integer, mft As Integer)
    CtrPoint.x = ctrx
    CtrPoint.y = ctry
    Top = t
    Bottom = b
    Left = l
    Right = r
    MaxFrameTime = mft

  End Sub
End Class

Public Class CArrFrame
  Public N As Integer
  Public Elmt As CElmtFrame()

  Public Sub New()
    N = 0
    ReDim Elmt(-1)
  End Sub

  Public Overloads Sub Insert(E As CElmtFrame)
    ReDim Preserve Elmt(N)
    Elmt(N) = E
    N = N + 1
  End Sub

  Public Overloads Sub Insert(ctrx As Integer, ctry As Integer, l As Integer, t As Integer, r As Integer, b As Integer, mft As Integer)
    Dim E As CElmtFrame
    E = New CElmtFrame(ctrx, ctry, l, t, r, b, mft)
    ReDim Preserve Elmt(N)
    Elmt(N) = E
    N = N + 1

  End Sub

End Class

Public Structure TPoint
  Dim x As Integer
  Dim y As Integer

End Structure

