package cn.com.dc.app.client.provider;

import java.lang.reflect.Field;

import cn.com.dc.app.client.bean.News;
import cn.com.dc.app.client.bean.PhoneInfo;
import android.content.Context;
import android.content.pm.PackageInfo;
import android.content.pm.PackageManager;
import android.content.pm.PackageManager.NameNotFoundException;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteDatabase.CursorFactory;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

public class SimpleSQLiteHelper {
	private static String TAG = "SimpleSQLiteHelper";
	private static Class[] tables = new Class[]{News.class, PhoneInfo.class};
	public static String[] namse;
	public static String DB_NAME = "dc_db";
	private DataBaseHelper dbHelper;
	private SQLiteDatabase sqliteDatabase = null;
	private Context mContext;
	public void open(Context context) {
		// 得到程序版本号
		mContext = context ;
		PackageManager pm = context.getPackageManager();
		int versionn = 1;
		try {
			PackageInfo pi = pm.getPackageInfo(context.getPackageName(), 0);
			// 得到程序版本号
			versionn = pi.versionCode;
			Log.i("test", "程序版本号" + versionn);
		} catch (NameNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		try {
			dbHelper = new DataBaseHelper(context, DB_NAME, null, versionn);
			sqliteDatabase = dbHelper.getReadableDatabase();
		
		} catch (Exception e) {
			// TODO: handle exception
			e.printStackTrace();
		}

	}
	public SQLiteDatabase getWritableDatabase()
	{
		if(dbHelper==null)
		{
			open(mContext);
		}
		return dbHelper.getWritableDatabase();
	}
	public SQLiteDatabase getReadableDatabase()
	{
		if(dbHelper==null)
		{
			open(mContext);
		}
		return dbHelper.getReadableDatabase() ;
	}
	private static class DataBaseHelper extends SQLiteOpenHelper {
		private Context mContext;
		public DataBaseHelper(Context context, String name,
				CursorFactory factory, int version) {
			super(context, name, factory, version);
			// TODO
			mContext = context;
		}

		@Override
		public void onCreate(SQLiteDatabase db) {
			// 根据 tables 获得表的名字和字段，而生成 数据库
			createTables(db);
		}

		private void createTables(SQLiteDatabase db) {
			// TODO
			for (Class cls : tables) {
				String sql = getSqlFromObject(cls);
				db.execSQL(sql);
			}

		}
		private String getSqlFromObject(Class cls) {
			StringBuffer sbf = new StringBuffer("create table ");
			String name = cls.getName();

			sbf.append(name.substring(name.lastIndexOf(".") + 1)).append("{");
			Field[] fds = cls.getDeclaredFields();

			sbf.append(" _id interger primary key AUTOINCREMENT , ");
			for (Field fd : fds) {
				System.out.println(fd.getName());
				String type = fd.getType().toString();
				if (fd.getName().contains("this$")) {
					continue;
				} else
					sbf.append(fd.getName()).append(" ");

				String col_type = null;
				if (type.contains("java.lang.String")) {
					col_type = " ntext ";
				} else if (type.contains("java.util.Date")) {
					col_type = (" date ");
				} else if (type.contains("float")) {
					col_type = (" FLOAT ");
				} else if (type.contains("int")) {
					col_type = (" INTEGER ");
				} else if (type.contains("char")) {
					col_type = (" char ");
				} else if (type.contains("double")) {
					col_type = (" decimal ");
				}
				if (col_type != null) {

					sbf.append(fd.getName()).append(" ").append(col_type)
							.append(",");
				}

			}
			sbf = sbf.deleteCharAt(sbf.length() - 1);
			sbf.append("}");
			System.out.println(sbf.toString());
			return sbf.toString();
		}

		@Override
		public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
			// TODO update the db

			Log.w(TAG, "Upgrading database from version " + oldVersion + " to "
					+ newVersion + ", which will destroy all old data");
			for (Class cls : tables) {
				StringBuffer sbf = new StringBuffer();
				sbf.append("DROP TABLE IF EXISTS ").append(cls.getName());
				db.execSQL(sbf.toString());
			}
			onCreate(db);
		}

	}
}
