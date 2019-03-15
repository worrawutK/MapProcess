Public Class clsShiftJISChar

#Region "�@LenB ���\�b�h�@"

    ''' -----------------------------------------------------------------------------------------
    ''' <summary>
    '''     ���p 1 �o�C�g�A�S�p 2 �o�C�g�Ƃ��āA�w�肳�ꂽ������̃o�C�g����Ԃ��܂��B</summary>
    ''' <param name="stTarget">
    '''     �o�C�g���擾�̑ΏۂƂȂ镶����B</param>
    ''' <returns>
    '''     ���p 1 �o�C�g�A�S�p 2 �o�C�g�ŃJ�E���g���ꂽ�o�C�g���B</returns>
    ''' -----------------------------------------------------------------------------------------
    Public Shared Function LenB(ByVal stTarget As String) As Integer
        Return System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(stTarget)
    End Function

#End Region


#Region "�@LeftByte ���\�b�h�@"

    ' -----------------------------------------------------------------------------------------
    ' <summary>
    '     ������̍��[����w�肵���o�C�g�����̕������Ԃ��܂��B</summary>
    ' <param name="stTarget">
    '     ���o�����ɂȂ镶����B<param>
    ' <param name="iByteSize">
    '     ���o���o�C�g���B</param>
    ' <returns>
    '     ���[����w�肳�ꂽ�o�C�g�����̕�����B</returns>
    ' -----------------------------------------------------------------------------------------
    Public Shared Function LeftByte(ByVal stTarget As String, ByVal iByteSize As Integer) As String
        Dim ans As String = ""
        For i As Integer = 0 To stTarget.Length - 1
            ans = stTarget.Substring(0, i)
            If LenB(ans & stTarget.Substring(i, 1)) > iByteSize Then
                Return ans
            End If
        Next
        Return stTarget
    End Function

#End Region

#Region "�@LeftB ���\�b�h�@"

    ' -----------------------------------------------------------------------------------------
    ' <summary>
    '     ������̍��[����w�肵���o�C�g�����̕������Ԃ��܂��B</summary>
    ' <param name="stTarget">
    '     ���o�����ɂȂ镶����B<param>
    ' <param name="iByteSize">
    '     ���o���o�C�g���B</param>
    ' <returns>
    '     ���[����w�肳�ꂽ�o�C�g�����̕�����B</returns>
    ' -----------------------------------------------------------------------------------------
    Public Shared Function LeftB(ByVal stTarget As String, ByVal iByteSize As Integer) As String
        Return MidB(stTarget, 1, iByteSize)
    End Function

#End Region

#Region "�@MidB ���\�b�h (+1)�@"

    ''' -----------------------------------------------------------------------------------------
    ''' <summary>
    '''     ������̎w�肳�ꂽ�o�C�g�ʒu�ȍ~�̂��ׂĂ̕������Ԃ��܂��B</summary>
    ''' <param name="stTarget">
    '''     ���o�����ɂȂ镶����B</param>
    ''' <param name="iStart">
    '''     ���o�����J�n����ʒu�B</param>
    ''' <returns>
    '''     �w�肳�ꂽ�o�C�g�ʒu�ȍ~�̂��ׂĂ̕�����B</returns>
    ''' -----------------------------------------------------------------------------------------
    Public Shared Function MidB(ByVal stTarget As String, ByVal iStart As Integer) As String
        Dim hEncoding As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim btBytes As Byte() = hEncoding.GetBytes(stTarget)

        Return hEncoding.GetString(btBytes, iStart - 1, btBytes.Length - iStart + 1)
    End Function

    ''' -----------------------------------------------------------------------------------------
    ''' <summary>
    '''     ������̎w�肳�ꂽ�o�C�g�ʒu����A�w�肳�ꂽ�o�C�g�����̕������Ԃ��܂��B</summary>
    ''' <param name="stTarget">
    '''     ���o�����ɂȂ镶����B</param>
    ''' <param name="iStart">
    '''     ���o�����J�n����ʒu�B</param>
    ''' <param name="iByteSize">
    '''     ���o���o�C�g���B</param>
    ''' <returns>
    '''     �w�肳�ꂽ�o�C�g�ʒu����w�肳�ꂽ�o�C�g�����̕�����B</returns>
    ''' -----------------------------------------------------------------------------------------
    Public Shared Function MidB _
    (ByVal stTarget As String, ByVal iStart As Integer, ByVal iByteSize As Integer) As String
        Dim hEncoding As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim btBytes As Byte() = hEncoding.GetBytes(stTarget)

        Return hEncoding.GetString(btBytes, iStart - 1, iByteSize)
    End Function

#End Region

#Region "�@RightB ���\�b�h�@"

    ''' -----------------------------------------------------------------------------------------
    ''' <summary>
    '''     ������̉E�[����w�肳�ꂽ�o�C�g�����̕������Ԃ��܂��B</summary>
    ''' <param name="stTarget">
    '''     ���o�����ɂȂ镶����B</param>
    ''' <param name="iByteSize">
    '''     ���o���o�C�g���B</param>
    ''' <returns>
    '''     �E�[����w�肳�ꂽ�o�C�g�����̕�����B</returns>
    ''' -----------------------------------------------------------------------------------------
    Public Shared Function RightB(ByVal stTarget As String, ByVal iByteSize As Integer) As String
        Dim hEncoding As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim btBytes As Byte() = hEncoding.GetBytes(stTarget)

        Return hEncoding.GetString(btBytes, btBytes.Length - iByteSize, iByteSize)
    End Function

#End Region


End Class

