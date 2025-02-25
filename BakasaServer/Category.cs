﻿namespace BakasaServer
{
    public class Category
    {
        public Category(string categoryName, List<string> categoryOptions)
        {
            CategoryName = categoryName;
            CategoryOptions = categoryOptions;
        }

        public string CategoryName { get; set; }
        public List<string> CategoryOptions { get; set; }
        public static List<Category> GetCategories()
        {

            return new List<Category>()
            {
                new Category("Jobs",["طبيب", "معلم", "مهندس", "ممرض", "ضابط شرطة", "رجل إطفاء", "ميكانيكي", "كهربائي", "طاهٍ", "طيار",
"محامي", "طبيب أسنان", "صيدلي", "طبيب بيطري", "مبرمج", "مترجم", "كاتب", "محاسب", "مصمم جرافيك", "صحفي",
"نجار", "حداد", "مزارع", "بائع", "سائق", "إداري", "مصور", "فنان", "مدير", "باحث",
"عالم", "عامل بناء", "خباز", "مدرب رياضي", "مرشد سياحي", "مضيف طيران", "موظف استقبال", "إطفائي", "عامل نظافة", "سكرتير",
"مهندس برمجيات", "أخصائي تسويق", "مدير مشروع", "أستاذ جامعي", "مدير موارد بشرية", "محلل مالي", "فني مختبر", "خبير اقتصادي", "رائد أعمال", "مهندس مدني"]
),
                new Category("Foods", ["بيتزا", "برجر", "كبسة", "مندي", "سوشي", "شاورما", "فلافل", "كباب", "باستا", "سمبوسة",
              "برياني", "ملوخية", "حمص", "فتوش", "ورق عنب", "محشي", "مانجو", "تمر", "عسل", "بطيخ",
              "شوربة", "شوكولاتة", "بوظة", "كيك", "بسبوسة", "كنافة", "لقيمات", "قطايف", "مهلبية", "أرز بالحليب",
              "سمك مشوي", "دجاج مشوي", "ستيك", "مقبلات", "مخللات", "زيتون", "جبن", "لبن", "قهوة", "شاي",
              "عصير برتقال", "عصير رمان", "عصير جوافة", "تمر هندي", "ليمونادة", "زنجبيل", "مشروب غازي", "حليب", "ماء", "سبانخ"]
),

new Category("Electronics", ["هاتف", "كمبيوتر", "لابتوب", "كاميرا", "سماعات", "ميكروفون", "لوحة مفاتيح", "فأرة", "تلفزيون", "طابعة",
                    "راوتر", "جهاز لوحي", "ساعة ذكية", "مكبر صوت", "مشغل ألعاب", "قرص صلب", "بطارية", "شاحن", "معالج", "ذاكرة وصول عشوائي",
                    "كابل HDMI", "محول طاقة", "شاشة لمس", "لوحة أم", "بطاقة رسومات", "مبرد معالج", "مسجل صوت", "مايكروفون لاسلكي", "هاتف أرضي", "فلاش ميموري",
                    "كاميرا مراقبة", "قارئ بصمات", "نظارات واقع افتراضي", "سماعات أذن", "ميكروفون مكثف", "راسم إشارة", "مكبر صوت بلوتوث", "جهاز تحكم عن بعد", "ميكروويف", "ثلاجة",
                    "غسالة", "فرن كهربائي", "مكنسة كهربائية", "جهاز عرض", "لوحة تحكم ذكية", "ميزان إلكتروني", "منبه رقمي", "مساعد صوتي", "منقي هواء", "جهاز تدفئة"]
),

new Category("League of Legends Characters", ["أهري", "ياسو", "زايا", "راكان", "جين", "كاتارينا", "إزريال", "داريوس", "لي سين", "ثريش",
                                     "لوكسانا", "شين", "مورغانا", "فين", "موردكايزر", "تايمو", "تويستد فيت", "أورني", "ريفن", "جيكس",
                                     "أش", "تريندامير", "سونا", "بلتزكرانك", "كاسادين", "جارفان الرابع", "ميليو", "أوفليا", "آكشان", "كاميليا",
                                     "كاين", "فيكتور", "إيلاوي", "إيكو", "سيلاس", "لولو", "نيدالي", "أورغوت", "بوبو", "كارثوس",
                                     "بانثيون", "زاك", "سيجون", "روندا", "بارد", "في", "كوبو", "ناوتيلوس", "زيرا", "إيفلين"]
),

new Category("Places", ["الحمام", "صالة البولينج", "المدرسة", "المكتبة", "الجامعة", "المستشفى", "الحديقة", "السوبرماركت", "المقهى", "المطعم",
               "المطار", "محطة القطار", "محطة الحافلات", "الملعب", "النادي الرياضي", "المسرح", "السينما", "المتحف", "المول", "المخبز",
               "محل الملابس", "محطة الوقود", "الصيدلية", "المغسلة", "البنك", "الحديقة العامة", "المصنع", "الورشة", "البرج", "السفينة",
               "الشارع", "الجسر", "النفق", "المزرعة", "الشاطئ", "المسبح", "الغابة", "المقبرة", "المسجد", "الكنيسة",
               "المعبد", "القاعة", "المكتب", "المنتزه", "الفندق", "السفارة", "المحكمة", "المخبز", "السوق", "المدينة الترفيهية"]
),

new Category("جماد", ["كتاب", "قلم", "كرسي", "طاولة", "ساعة", "مرآة", "مصباح", "حقيبة", "زجاجة", "نافذة",
              "باب", "جدار", "سقف", "أرضية", "جهاز تحكم", "جهاز تلفاز", "وسادة", "بطانية", "هاتف", "كمبيوتر",
              "صندوق", "مروحة", "ثلاجة", "غسالة", "سيارة", "دراجة", "لوحة", "صورة", "خزانة", "فرشاة",
              "مظلة", "علبة", "مقص", "مشط", "سكين", "شوكة", "ملعقة", "طبق", "كوب", "غلاية",
              "قدر", "مقلاة", "جهاز قياس", "ميزان", "مكبر صوت", "مصباح يدوي", "كشاف", "خاتم", "سلسلة", "نظارات"]
),

new Category("حيوان", ["أسد", "نمر", "فيل", "زرافة", "ذئب", "ثعلب", "دب", "نسر", "بومة", "غزال",
               "خروف", "ماعز", "حصان", "جمل", "كلب", "قط", "أرنب", "فهد", "تمساح", "سلحفاة",
               "حمار", "بقرة", "دلفين", "سمكة", "بطريق", "نورس", "غراب", "ببغاء", "عصفور", "نملة",
               "نحلة", "دب قطبي", "ثعبان", "ضفدع", "تمساح", "حوت", "قرش", "راكون", "غرير", "طاووس",
               "بجع", "حمار وحشي", "كوالا", "كنغر", "شيهم", "ظبي", "غوريلا", "شمبانزي", "خفاش", "أخطبوط"]
),

new Category("أكلات", ["كبسة", "مندي", "مشاوي", "ورق عنب", "محشي", "ملوخية", "برياني", "مقلوبة", "شاورما", "حمص",
              "تبولة", "فتوش", "يخنة", "كبة", "بيتزا", "برجر", "باستا", "سمبوسة", "بسبوسة", "كنافة",
              "مهلبية", "لقيمات", "قطايف", "أرز بالحليب", "حساء العدس", "فول مدمس", "عجة", "بيض مسلوق", "بطاطس مقلية", "جمبري مشوي",
              "ستيك", "دجاج مشوي", "مقبلات", "مخللات", "زيتون", "جبن", "لبن", "فطائر", "زنجبيل", "تمر هندي",
              "عصير برتقال", "عصير رمان", "قهوة", "شاي", "ماء", "تمر", "مانجو", "تفاح", "برتقال", "فراولة"]
)

            };
        }
    }
}
