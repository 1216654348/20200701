using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.LocalHostModel
{
    public partial class lzjcContext : DbContext
    {
        public lzjcContext()
        {
        }

        public lzjcContext(DbContextOptions<lzjcContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GlyjcYkljcqy> GlyjcYkljcqy { get; set; }
        public virtual DbSet<JieruConfig> JieruConfig { get; set; }
        public virtual DbSet<LeshanRykl> LeshanRykl { get; set; }
        public virtual DbSet<LeshanSsykl> LeshanSsykl { get; set; }
        public virtual DbSet<TTempCxph> TTempCxph { get; set; }
        public virtual DbSet<TTempFkhx> TTempFkhx { get; set; }
        public virtual DbSet<TTempGgcl> TTempGgcl { get; set; }
        public virtual DbSet<TTempJcsbxx> TTempJcsbxx { get; set; }
        public virtual DbSet<TTempKyjgcs> TTempKyjgcs { get; set; }
        public virtual DbSet<TTempKyjgs> TTempKyjgs { get; set; }
        public virtual DbSet<TTempRkll> TTempRkll { get; set; }
        public virtual DbSet<TTempYjzh> TTempYjzh { get; set; }
        public virtual DbSet<TTempYkll> TTempYkll { get; set; }
        public virtual DbSet<TTempYqrs> TTempYqrs { get; set; }
        public virtual DbSet<YsjYwbysj> YsjYwbysj { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=127.0.0.1;userid=root;pwd=password;port=3306;database=lzjc", x => x.ServerVersion("8.0.20-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GlyjcYkljcqy>(entity =>
            {
                entity.ToTable("glyjc_ykljcqy");

                entity.HasComment("游客量监测区域");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Cjrid)
                    .HasColumnName("CJRID")
                    .HasColumnType("varchar(500)")
                    .HasComment("创建人id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Cjsj)
                    .HasColumnName("CJSJ")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.Djrid)
                    .HasColumnName("DJRID")
                    .HasColumnType("varchar(50)")
                    .HasComment("对接人id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Djsj)
                    .HasColumnName("DJSJ")
                    .HasColumnType("datetime")
                    .HasComment("对接时间");

                entity.Property(e => e.Fw)
                    .HasColumnName("FW")
                    .HasColumnType("varchar(5000)")
                    .HasComment("范围")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Jd)
                    .HasColumnName("JD")
                    .HasColumnType("varchar(50)")
                    .HasComment("经度")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Lscgfwrs)
                    .HasColumnName("LSCGFWRS")
                    .HasComment("历史参观访问人数");

                entity.Property(e => e.Lx)
                    .HasColumnName("LX")
                    .HasColumnType("varchar(500)")
                    .HasComment("类型")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Mc)
                    .HasColumnName("MC")
                    .HasColumnType("varchar(500)")
                    .HasComment("名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Rwid)
                    .HasColumnName("RWID")
                    .HasColumnType("varchar(50)")
                    .HasComment("任务ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Ryklxxz)
                    .HasColumnName("RYKLXXZ")
                    .HasComment("日游客量限制值");

                entity.Property(e => e.Sfkdj)
                    .HasColumnName("SFKDJ")
                    .HasComment("是否可对接");

                entity.Property(e => e.Sfydj)
                    .HasColumnName("SFYDJ")
                    .HasComment("是否已对接");

                entity.Property(e => e.Shrid)
                    .HasColumnName("SHRID")
                    .HasColumnType("varchar(500)")
                    .HasComment("审核人id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Shsj)
                    .HasColumnName("SHSJ")
                    .HasColumnType("datetime")
                    .HasComment("审核时间");

                entity.Property(e => e.Shyc)
                    .HasColumnName("SHYC")
                    .HasColumnType("varchar(200)")
                    .HasDefaultValueSql("''")
                    .HasComment("审核游程")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Shzt)
                    .HasColumnName("SHZT")
                    .HasComment("审核状态");

                entity.Property(e => e.Ssjd)
                    .HasColumnName("SSJD")
                    .HasColumnType("varchar(500)")
                    .HasComment("所属景点")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Ssjdmc)
                    .HasColumnName("SSJDMC")
                    .HasColumnType("varchar(500)")
                    .HasComment("所属景点名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Ssyklxzz)
                    .HasColumnName("SSYKLXZZ")
                    .HasComment("瞬时游客量限制值");

                entity.Property(e => e.Tjsj)
                    .HasColumnName("TJSJ")
                    .HasColumnType("datetime")
                    .HasComment("提交时间");

                entity.Property(e => e.Wd)
                    .HasColumnName("WD")
                    .HasColumnType("varchar(50)")
                    .HasComment("纬度")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Wzms)
                    .HasColumnName("WZMS")
                    .HasColumnType("varchar(1000)")
                    .HasComment("位置描述")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<JieruConfig>(entity =>
            {
                entity.ToTable("jieru_config");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("varchar(80)")
                    .HasComment("主键")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AlertJudgeUrl)
                    .HasColumnName("alert_judge_url")
                    .HasColumnType("varchar(255)")
                    .HasComment("预警数据抓取为位置url")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Fkey)
                    .HasColumnName("fkey")
                    .HasColumnType("varchar(50)")
                    .HasComment("外键-监测点ID或设备ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Fkeytype)
                    .HasColumnName("fkeytype")
                    .HasColumnType("varchar(50)")
                    .HasComment("外键类别0-设备，1-监测点")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.GrabCycle)
                    .HasColumnName("grab_cycle")
                    .HasComment("抓取周期（单位：秒）");

                entity.Property(e => e.GrabCycleUnit)
                    .HasColumnName("grab_cycle_unit")
                    .HasColumnType("varchar(255)")
                    .HasComment("抓取周期单位")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.GrabError)
                    .HasColumnName("grab_error")
                    .HasComment("抓取误差（秒）");

                entity.Property(e => e.GrabMainUrl)
                    .HasColumnName("grab_main_url")
                    .HasColumnType("varchar(255)")
                    .HasComment("数据抓取地址（只有一个抓取url）")
                    .HasCharSet("utf32")
                    .HasCollation("utf32_general_ci");

                entity.Property(e => e.GrabType)
                    .IsRequired()
                    .HasColumnName("grab_type")
                    .HasColumnType("varchar(40)")
                    .HasComment("抓取类型")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否启动(0-未启动,1-启动)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsStorage)
                    .HasColumnName("is_storage")
                    .HasComment("是否存库");

                entity.Property(e => e.LastGrabTime)
                    .HasColumnName("last_grab_time")
                    .HasColumnType("datetime")
                    .HasComment("上次抓取时间");

                entity.Property(e => e.ManagerId)
                    .HasColumnName("manager_id")
                    .HasColumnType("varchar(50)")
                    .HasComment("负责人id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasColumnType("varchar(255)")
                    .HasComment("备注")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RemarkName)
                    .HasColumnName("remark_name")
                    .HasColumnType("varchar(50)")
                    .HasComment("所属名称(自然环境-大屏)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<LeshanRykl>(entity =>
            {
                entity.ToTable("leshan_rykl");

                entity.HasComment("日游客量");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Cjrid)
                    .HasColumnName("CJRID")
                    .HasColumnType("varchar(50)")
                    .HasComment("创建人ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Cjsj)
                    .HasColumnName("CJSJ")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.Djrid)
                    .HasColumnName("DJRID")
                    .HasColumnType("varchar(50)")
                    .HasComment("对接人ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Djsj)
                    .HasColumnName("DJSJ")
                    .HasColumnType("datetime")
                    .HasComment("对接时间");

                entity.Property(e => e.NumEnter)
                    .HasColumnName("num_enter")
                    .HasComment("景点实时入园人数");

                entity.Property(e => e.NumIn)
                    .HasColumnName("num_in")
                    .HasComment("景点实时在园人数");

                entity.Property(e => e.Rksj)
                    .HasColumnName("RKSJ")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("入库时间");

                entity.Property(e => e.Rwid)
                    .HasColumnName("RWID")
                    .HasColumnType("varchar(50)")
                    .HasComment("任务ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Sfkdj)
                    .HasColumnName("SFKDJ")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否可对接");

                entity.Property(e => e.Sfydj)
                    .HasColumnName("SFYDJ")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否已对接");

                entity.Property(e => e.Shrid)
                    .HasColumnName("SHRID")
                    .HasColumnType("varchar(50)")
                    .HasComment("审核人ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Shsj)
                    .HasColumnName("SHSJ")
                    .HasColumnType("datetime")
                    .HasComment("审核时间");

                entity.Property(e => e.Shyc)
                    .HasColumnName("SHYC")
                    .HasColumnType("varchar(200)")
                    .HasDefaultValueSql("''")
                    .HasComment("审核游程")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Shzt)
                    .HasColumnName("SHZT")
                    .HasComment("审核状态");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("datetime")
                    .HasComment("时间");

                entity.Property(e => e.Tjsj)
                    .HasColumnName("TJSJ")
                    .HasColumnType("datetime")
                    .HasComment("提交时间");

                entity.Property(e => e.Ykqyid)
                    .HasColumnName("YKQYID")
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("''")
                    .HasComment("游客区域id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<LeshanSsykl>(entity =>
            {
                entity.ToTable("leshan_ssykl");

                entity.HasComment("瞬时游客量");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("Id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Cjrid)
                    .HasColumnName("CJRID")
                    .HasColumnType("varchar(50)")
                    .HasComment("创建人ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Cjsj)
                    .HasColumnName("CJSJ")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.Djrid)
                    .HasColumnName("DJRID")
                    .HasColumnType("varchar(50)")
                    .HasComment("对接人ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Djsj)
                    .HasColumnName("DJSJ")
                    .HasColumnType("datetime")
                    .HasComment("对接时间");

                entity.Property(e => e.NumEnter)
                    .HasColumnName("num_enter")
                    .HasComment("景点实时入园人数");

                entity.Property(e => e.NumIn)
                    .HasColumnName("num_in")
                    .HasComment("景点实时在园人数");

                entity.Property(e => e.Rwid)
                    .HasColumnName("RWID")
                    .HasColumnType("varchar(50)")
                    .HasComment("任务ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Sfkdj)
                    .HasColumnName("SFKDJ")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否可对接");

                entity.Property(e => e.Sfydj)
                    .HasColumnName("SFYDJ")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否已对接");

                entity.Property(e => e.Shrid)
                    .HasColumnName("SHRID")
                    .HasColumnType("varchar(50)")
                    .HasComment("审核人ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Shsj)
                    .HasColumnName("SHSJ")
                    .HasColumnType("datetime")
                    .HasComment("审核时间");

                entity.Property(e => e.Shyc)
                    .HasColumnName("SHYC")
                    .HasColumnType("varchar(200)")
                    .HasDefaultValueSql("''")
                    .HasComment("审核游程")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Shzt)
                    .HasColumnName("SHZT")
                    .HasComment("审核状态");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("datetime")
                    .HasComment("时间");

                entity.Property(e => e.Tjsj)
                    .HasColumnName("TJSJ")
                    .HasColumnType("datetime")
                    .HasComment("提交时间");

                entity.Property(e => e.Ykqyid)
                    .HasColumnName("YKQYID")
                    .HasColumnType("varchar(50)")
                    .HasComment("游客区域id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<TTempCxph>(entity =>
            {
                entity.ToTable("t_temp_cxph");

                entity.HasComment("出行偏好");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Cjsj)
                    .HasColumnName("CJSJ")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.Cllx)
                    .HasColumnName("CLLX")
                    .HasColumnType("varchar(50)")
                    .HasComment("车辆类型")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Czbl)
                    .HasColumnName("CZBL")
                    .HasColumnType("decimal(10,2)")
                    .HasComment("乘坐比例");

                entity.Property(e => e.Rksj)
                    .HasColumnName("RKSJ")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("入库时间");
            });

            modelBuilder.Entity<TTempFkhx>(entity =>
            {
                entity.ToTable("t_temp_fkhx");

                entity.HasComment("访客画像(近一周)");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Cjsj)
                    .HasColumnName("CJSJ")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.Femalerate)
                    .HasColumnName("FEMALERATE")
                    .HasColumnType("decimal(10,2)")
                    .HasComment("女性游客比例");

                entity.Property(e => e.Malerate)
                    .HasColumnName("MALERATE")
                    .HasColumnType("decimal(10,2)")
                    .HasComment("男性游客比例");

                entity.Property(e => e.Rksj)
                    .HasColumnName("RKSJ")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("入库时间");

                entity.Property(e => e.Unknownage)
                    .HasColumnName("UNKNOWNAGE")
                    .HasColumnType("decimal(10,2)")
                    .HasComment("未知年龄比例");

                entity.Property(e => e.Unknownrate)
                    .HasColumnName("UNKNOWNRATE")
                    .HasColumnType("decimal(10,2)")
                    .HasComment("未知游客性别比例");

                entity.Property(e => e._19)
                    .HasColumnName("<19")
                    .HasColumnType("decimal(10,2)")
                    .HasComment("<19比例");

                entity.Property(e => e._1925)
                    .HasColumnName("19-25")
                    .HasColumnType("decimal(10,2)")
                    .HasComment("19-25比例");

                entity.Property(e => e._2635)
                    .HasColumnName("26-35")
                    .HasColumnType("decimal(10,2)")
                    .HasComment("26-35比例");

                entity.Property(e => e._3645)
                    .HasColumnName("36-45")
                    .HasColumnType("decimal(10,2)")
                    .HasComment("36-45比例");

                entity.Property(e => e._4655)
                    .HasColumnName("46-55")
                    .HasColumnType("decimal(10,2)")
                    .HasComment("46-55比例");

                entity.Property(e => e._55)
                    .HasColumnName(">55")
                    .HasColumnType("decimal(10,2)")
                    .HasComment(">55比例");
            });

            modelBuilder.Entity<TTempGgcl>(entity =>
            {
                entity.ToTable("t_temp_ggcl");

                entity.HasComment("观光车辆使用");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Allusesightcarnum)
                    .HasColumnName("ALLUSESIGHTCARNUM")
                    .HasComment("总量");

                entity.Property(e => e.Cjsj)
                    .HasColumnName("CJSJ")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.Faultsightcarnum)
                    .HasColumnName("FAULTSIGHTCARNUM")
                    .HasComment("挂故障");

                entity.Property(e => e.Inusesightcarnum)
                    .HasColumnName("INUSESIGHTCARNUM")
                    .HasComment("使用");

                entity.Property(e => e.Remainsightcarnum)
                    .HasColumnName("REMAINSIGHTCARNUM")
                    .HasComment("剩余(空闲中)");

                entity.Property(e => e.Rksj)
                    .HasColumnName("RKSJ")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("入库时间");
            });

            modelBuilder.Entity<TTempJcsbxx>(entity =>
            {
                entity.ToTable("t_temp_jcsbxx");

                entity.HasComment("基础设备信息(停车位/闸机/观光车)");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Cjsj)
                    .HasColumnName("CJSJ")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.Inusegatenum)
                    .HasColumnName("INUSEGATENUM")
                    .HasComment("闸机-使用中");

                entity.Property(e => e.Inuseparknum)
                    .HasColumnName("INUSEPARKNUM")
                    .HasComment("停车位-使用中");

                entity.Property(e => e.Inusesightcarnum)
                    .HasColumnName("INUSESIGHTCARNUM")
                    .HasComment("观光车-使用中");

                entity.Property(e => e.Remaingatenum)
                    .HasColumnName("REMAINGATENUM")
                    .HasComment("闸机-剩余");

                entity.Property(e => e.Remainparknum)
                    .HasColumnName("REMAINPARKNUM")
                    .HasComment("停车位-剩余");

                entity.Property(e => e.Rksj)
                    .HasColumnName("RKSJ")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("入库时间");
            });

            modelBuilder.Entity<TTempKyjgcs>(entity =>
            {
                entity.ToTable("t_temp_kyjgcs");

                entity.HasComment("客源结构(近一周)城市");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Bszb)
                    .HasColumnName("BSZB")
                    .HasColumnType("decimal(10,2)")
                    .HasComment("本省占比");

                entity.Property(e => e.Cjsj)
                    .HasColumnName("CJSJ")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.Dyfb)
                    .HasColumnName("DYFB")
                    .HasColumnType("varchar(50)")
                    .HasComment("地域分布(城市)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Rksj)
                    .HasColumnName("RKSJ")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("入库时间");
            });

            modelBuilder.Entity<TTempKyjgs>(entity =>
            {
                entity.ToTable("t_temp_kyjgs");

                entity.HasComment("客源结构(近一周)省");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Cjsj)
                    .HasColumnName("CJSJ")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.Dyfb)
                    .HasColumnName("DYFB")
                    .HasColumnType("varchar(50)")
                    .HasComment("地域分布(省)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Qgzb)
                    .HasColumnName("QGZB")
                    .HasColumnType("decimal(10,2)")
                    .HasComment("全国占比");

                entity.Property(e => e.Rksj)
                    .HasColumnName("RKSJ")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("入库时间");
            });

            modelBuilder.Entity<TTempRkll>(entity =>
            {
                entity.ToTable("t_temp_rkll");

                entity.HasComment("入口流量");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Cjsj)
                    .HasColumnName("CJSJ")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.Rkmc)
                    .HasColumnName("RKMC")
                    .HasColumnType("varchar(50)")
                    .HasComment("入口名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Rkrsbl)
                    .HasColumnName("RKRSBL")
                    .HasColumnType("decimal(10,2)")
                    .HasComment("入口人数比例");

                entity.Property(e => e.Rksj)
                    .HasColumnName("RKSJ")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("入库时间");
            });

            modelBuilder.Entity<TTempYjzh>(entity =>
            {
                entity.ToTable("t_temp_yjzh");

                entity.HasComment("应急指挥");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Cjsj)
                    .HasColumnName("CJSJ")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.Emergencyindex)
                    .HasColumnName("EMERGENCYINDEX")
                    .HasColumnType("varchar(50)")
                    .HasComment("名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Emergencytype)
                    .HasColumnName("EMERGENCYTYPE")
                    .HasColumnType("varchar(50)")
                    .HasComment(@"类型((bus_station=观光车站点/emergency_exit=应急出
口/fire_evacuation_station=消防避难点)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Latitude)
                    .HasColumnName("LATITUDE")
                    .HasColumnType("varchar(50)")
                    .HasComment("纬度")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Longitude)
                    .HasColumnName("LONGITUDE")
                    .HasColumnType("varchar(50)")
                    .HasComment("经度")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Rksj)
                    .HasColumnName("RKSJ")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("入库时间");
            });

            modelBuilder.Entity<TTempYkll>(entity =>
            {
                entity.ToTable("t_temp_ykll");

                entity.HasComment("游客流量");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Cjsj)
                    .HasColumnName("CJSJ")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.Preentrancecount)
                    .HasColumnName("PREENTRANCECOUNT")
                    .HasComment("当日预约人数");

                entity.Property(e => e.Rksj)
                    .HasColumnName("RKSJ")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("入库时间");

                entity.Property(e => e.Totalcount)
                    .HasColumnName("TOTALCOUNT")
                    .HasComment("当日到达人数");
            });

            modelBuilder.Entity<TTempYqrs>(entity =>
            {
                entity.ToTable("t_temp_yqrs");

                entity.HasComment("舆情热搜");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Cjsj)
                    .HasColumnName("CJSJ")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.Rksj)
                    .HasColumnName("RKSJ")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("入库时间");

                entity.Property(e => e.Rsmc)
                    .HasColumnName("RSMC")
                    .HasColumnType("varchar(50)")
                    .HasComment("热搜名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Rssl)
                    .HasColumnName("RSSL")
                    .HasComment("热搜数量");
            });

            modelBuilder.Entity<YsjYwbysj>(entity =>
            {
                entity.ToTable("ysj_ywbysj");

                entity.HasComment("业务表元数据");

                entity.HasIndex(e => e.Fjid)
                    .HasName("FK_09A5C77C594D4B4A");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Bbgdzq)
                    .HasColumnName("BBGDZQ")
                    .HasDefaultValueSql("'0'")
                    .HasComment("版本归档周期（以天为单位，默认为半年）");

                entity.Property(e => e.Bbm)
                    .HasColumnName("BBM")
                    .HasColumnType("varchar(50)")
                    .HasComment("表别名")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Bmc)
                    .HasColumnName("BMC")
                    .HasColumnType("varchar(50)")
                    .HasComment("表名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Ccxdlj)
                    .HasColumnName("CCXDLJ")
                    .HasColumnType("varchar(100)")
                    .HasComment("存储相对路径(以作废，2018年2月9日11:26:49)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Dyfjzdm)
                    .HasColumnName("DYFJZDM")
                    .HasColumnType("varchar(50)")
                    .HasComment("对应附件字段名(移动端采集的照片对应表中的字段)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Fjid)
                    .HasColumnName("FJID")
                    .HasColumnType("varchar(50)")
                    .HasComment("父级ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Fjwjjm)
                    .HasColumnName("FJWJJM")
                    .HasColumnType("varchar(500)")
                    .HasComment("附件（存放的）文件夹名")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Ftp)
                    .HasColumnName("FTP")
                    .HasColumnType("varchar(50)")
                    .HasComment("账户")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Fwffqz)
                    .HasColumnName("FWFFQZ")
                    .HasColumnType("varchar(50)")
                    .HasComment("服务方法前缀")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Jcpzst)
                    .HasColumnName("JCPZST")
                    .HasColumnType("varchar(255)")
                    .HasComment("监测配置视图")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Jcxtimefield)
                    .HasColumnName("JCXTIMEFIELD")
                    .HasColumnType("varchar(50)")
                    .HasComment("监测项时间字段名")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Kz1)
                    .HasColumnName("KZ1")
                    .HasColumnType("varchar(200)")
                    .HasComment("扩展1")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Kz2)
                    .HasColumnName("KZ2")
                    .HasColumnType("varchar(200)")
                    .HasComment("扩展2")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Kz3)
                    .HasColumnName("KZ3")
                    .HasColumnType("varchar(200)")
                    .HasComment("扩展3")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Kz4)
                    .HasColumnName("KZ4")
                    .HasColumnType("varchar(200)")
                    .HasComment("扩展4")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Kz5)
                    .HasColumnName("KZ5")
                    .HasColumnType("varchar(200)")
                    .HasComment("扩展5")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Px)
                    .HasColumnName("PX")
                    .HasComment("排序");

                entity.Property(e => e.Sfbbgd)
                    .HasColumnName("SFBBGD")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否版本归档");

                entity.Property(e => e.Sfrwxjc)
                    .HasColumnName("SFRWXJC")
                    .HasComment("是否任务型监测");

                entity.Property(e => e.Sfwjcx)
                    .HasColumnName("SFWJCX")
                    .HasComment("是否为监测项");

                entity.Property(e => e.Sfyfj)
                    .HasColumnName("SFYFJ")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否有附件");

                entity.Property(e => e.Wjccwldz)
                    .HasColumnName("WJCCWLDZ")
                    .HasColumnType("varchar(100)")
                    .HasComment("文件存储物理地址")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Yjlx)
                    .HasColumnName("YJLX")
                    .HasColumnType("varchar(10)")
                    .HasComment("预警类型")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Yjyzlx)
                    .HasColumnName("YJYZLX")
                    .HasComment("预警阈值类型，系统生成预警信息使用（枚举型：0，数值型：1）");

                entity.Property(e => e.Ysjbbm)
                    .HasColumnName("YSJBBM")
                    .HasColumnType("varchar(50)")
                    .HasComment("元数据表表名")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Ywzj)
                    .HasColumnName("YWZJ")
                    .HasColumnType("varchar(50)")
                    .HasComment("业务主键(设备类中对应为数据表中的外键字段名)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Zstmc)
                    .HasColumnName("ZSTMC")
                    .HasColumnType("varchar(50)")
                    .HasComment("主视图名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
