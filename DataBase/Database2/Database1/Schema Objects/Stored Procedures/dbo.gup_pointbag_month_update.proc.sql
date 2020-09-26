﻿CREATE PROCEDURE [dbo].[gup_pointbag_month_update]
	@iLoginUID_ [int],
	@sdtRegDate_ [smalldatetime],
	@iItemID_ [int],
	@iOK [int] = 0
AS
/*microcat
작성일 : 2007년 4월 23일
사용 : 유저의 월별 아이템을 받아갔다고 알려준다.
*/
SET NOCOUNT ON;

if not exists(select * from dbo.GPointBag with (nolock) where LoginUID = @iLoginUID_)
    begin    select @iOK = -1    goto end_proc    end

select @sdtRegDate_ = dateadd(mm, 1, convert(nvarchar(8), @sdtRegDate_, 120) + N'01') - 1

if not exists(select * from dbo.GPointBagMonth with (nolock) where LoginUID = @iLoginUID_ and RegDate = @sdtRegDate_)
    begin    select @iOK = -2    goto end_proc    end

if @iItemID_ = -1
    begin    select @iOK = -3    goto end_proc    end

begin tran
    update dbo.GPointBagMonth with (rowlock)
        set ItemID = @iItemID_
            where LoginUID = @iLoginUID_ and RegDate = @sdtRegDate_
    if @@error <> 0 or @@rowcount <> 1
        begin    select @iOK = -11    goto fail_tran    end
commit tran

goto end_proc

fail_tran:
rollback tran

end_proc:
select @iOK

