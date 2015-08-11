ALTER TABLE STOCK add SizeEnglish varchar(50)
go
ALTER TABLE STOCK add SizeFrench varchar(50)
go
UPDATE Stock set SizeEnglish = size
go
UPDATE Stock set SizeFrench = size
go
UPDATE Stock set SizeEnglish = '(3XL) 3XLarge' WHERE Size = '3XL'
UPDATE Stock set SizeEnglish = '(2XL) 2XLarge' WHERE Size = '2XL'
UPDATE Stock set SizeEnglish = '(XL) XLarge' WHERE Size = 'XL'
UPDATE Stock set SizeEnglish = '(L) Large' WHERE Size = 'L'
UPDATE Stock set SizeEnglish = '(M) Medium' WHERE Size = 'M'
UPDATE Stock set SizeEnglish = '(S) Small' WHERE Size = 'S'
UPDATE Stock set SizeEnglish = '(S/M) Small/Medium' WHERE Size = 'S/M'
UPDATE Stock set SizeEnglish = '(M/L) Medium/Large' WHERE Size = 'M/L'
UPDATE Stock set SizeEnglish = '(L/XL) Large/XLarge' WHERE Size = 'L/XL'
UPDATE Stock set SizeEnglish = '(XL/2XL) XLarge/2XLarge' WHERE Size = 'XL/2XL'
UPDATE Stock set SizeEnglish = '(4XL) 4XLarge' WHERE Size = '4XL'
UPDATE Stock set SizeEnglish = '(5XL) 5XLarge' WHERE Size = '5XL'
UPDATE Stock set SizeEnglish = '(YXS) Y XSmall' WHERE Size = 'YXS'
UPDATE Stock set SizeEnglish = '(XS) XSmall' WHERE Size = 'XS'
UPDATE Stock set SizeEnglish = '(YS) Y Small' WHERE Size = 'YS'
UPDATE Stock set SizeEnglish = '(YL) Y Large' WHERE Size = 'YL'
UPDATE Stock set SizeEnglish = '(YXL) Y XLarge' WHERE Size = 'YXL'

UPDATE Stock set SizeFrench = '(3XL) 3XLarge' WHERE Size = '3XL'
UPDATE Stock set SizeFrench = '(2XL) 2XLarge' WHERE Size = '2XL'
UPDATE Stock set SizeFrench = '(XL) XLarge' WHERE Size = 'XL'
UPDATE Stock set SizeFrench = '(L) Large' WHERE Size = 'L'
UPDATE Stock set SizeFrench = '(M) Medium' WHERE Size = 'M'
UPDATE Stock set SizeFrench = '(P) Petit' WHERE Size = 'S'
UPDATE Stock set SizeFrench = '(P/M) Petit/Medium' WHERE Size = 'S/M'
UPDATE Stock set SizeFrench = '(M/L) Medium/Large' WHERE Size = 'M/L'
UPDATE Stock set SizeFrench = '(L/XL) Large/XLarge' WHERE Size = 'L/XL'
UPDATE Stock set SizeFrench = '(XL/2XL) XLarge/2XLarge' WHERE Size = 'XL/2XL'
UPDATE Stock set SizeFrench = '(4XL) 4XLarge' WHERE Size = '4XL'
UPDATE Stock set SizeFrench = '(5XL) 5XLarge' WHERE Size = '5XL'
UPDATE Stock set SizeFrench = '(YXP) Y XPetit' WHERE Size = 'YXS'
UPDATE Stock set SizeFrench = '(XP) XPetit' WHERE Size = 'XS'
UPDATE Stock set SizeFrench = '(YP) Y Petit' WHERE Size = 'YS'
UPDATE Stock set SizeFrench = '(YL) Y Large' WHERE Size = 'YL'
UPDATE Stock set SizeFrench = '(YXL) Y XLarge' WHERE Size = 'YXL'
go
UPDATE STOCK set FeatureEnglish = SizeEnglish + ' - ' + ColorEnglish, FeatureFrench = SizeFrench + ' - ' + ColorFrench
UPDATE STOCK set ComboboxDescription = FeatureEnglish
go
ALTER TABLE Stock DROP COLUMN SizeEnglish
go
ALTER TABLE Stock DROP COLUMN SizeFrench
