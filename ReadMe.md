# 步骤框架

##音频

### 音频文件命名规范
- 音频文件要按照大章节_小章节_编号,来命名.
  - 如雷达开机启动流程第四节音频则写成 : Radar_Startup_004
- u3d打包则按照大章节来打包
  - 如雷达包,则为Radar.audiopackage

## 重置

- 重置都继承IReset接口

## UI
- 一个创建button的时候添加ButtonGroup.cs脚本, 用来管理整个button组件
