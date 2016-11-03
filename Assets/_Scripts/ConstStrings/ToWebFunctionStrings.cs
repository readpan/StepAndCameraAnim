public static class ToWebFunctionStrings
{
    /// <summary>
    /// 是否进入新手
    /// </summary>
    public const string isEnterGuide = "isEnterGuide";

    /// <summary>
    /// 结束新手引导 overGuide(isFinished)
    /// </summary>
    public const string overGuide = "overGuide";

    /// <summary>
    /// 实时 记录学习章节函数saveStudyChapter(deviceId, chapterId)   
    /// </summary>
    public const string saveStudyChapter = "saveStudyChapter";

    /// <summary>
    /// 调用flash流程图函数  showFlowChart(deviceId) 
    /// </summary>
    public const string showFlowChart = "showFlowChart";

    /// <summary>
    /// 退出信号流向图
    /// </summary>
    public const string isrightequipment = "IsRightEquipment";

    /// <summary>
    /// 设备web弹出维护软件步骤图
    /// </summary>
    public const string popupEquipMainten = "PopupEquipMainten";
    /// <summary>
    /// 根据章节传提示语
    /// </summary>
    public const string getnpcByChapterId = "getNpcByChapterId";
    /// <summary>
    /// 打开web流程图
    /// 2016-4-14 15:52:38应web需求去掉 BY:GF
    /// </summary>
    public const string openWebFlowchat = "OpenWebFlowChat";
    /// <summary>
    /// 传给web值,选择哪个流程图（string "1" or"2"）
    /// 2016-3-23 18:44:34 应web需求去掉 BY:GF
    /// </summary>
   // public const string selectSmallEquip = "SelectSmallEquip";

    /// <summary>
    /// 弹出格雷码Flash
    /// </summary>
    public const string grayCodePlateFlash = "GrayCodePlateFlash";

    /// <summary>
    /// 弹出吊绳Flash
    /// </summary>
    public const string liftingRopeFlash = "LiftingRopeFlash ";

    /// <summary>
    /// 弹出设备相对应的流程图 PopupFlowChart(string equipID,string 1or 2,string canClickFlash or noClickFlash)
    /// </summary>
    public const string popupFlowChart = "PopupFlowChart";
    /// <summary>
    /// 弹出能见度的工作原理图的 flash
    /// </summary>
    public const string visibilityFlash = "visibilityFlash ";
    /// <summary>
    /// 弹出雨量更换量筒 flash
    /// </summary>
    public const string rainSensorGengHuanFlash = "precipitationTube ";
    /// <summary>
    /// 调用web 的方法为了拿到章节提示语
    /// </summary>
    public const string receiveChapterInstroByType = "receiveChapterInstroByType ";
    /// <summary>
    /// 调用web 万用表烧了的flash 
    /// </summary>
    public const string multimeterBurn = "multimeterBurn";
    /// <summary>
    /// 测量草高度
    /// </summary>
    public const string grassHighFlash = "grassHighFlash";
    /// <summary>
    /// 草温积雪清理
    /// </summary>
    public const string grassSnowClean = "grassSnowClean";
    /// <summary>
    /// 气压维护
    /// </summary>
    public const string pressureSensor = "pressureSensor";
    public const string replaceSIMCard = "replaceSIMCard";

    public const string BackToWeb = "BackToWeb";
}
